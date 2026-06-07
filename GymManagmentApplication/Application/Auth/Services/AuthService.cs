using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GymManagmentApplication.Application.Auth.Interfaces;
using GymManagmentApplication.Application.Auth.Requests;
using GymManagmentApplication.Application.Auth.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GymManagmentApplication.Application.Auth.Services;

public class AuthService(IOptions<JwtSettings> jwtOptions) : IAuthService
{
    private readonly JwtSettings _jwt = jwtOptions.Value;

    private static readonly List<SeedUser> _users =
    [
        new(1, "admin@gym.com",   Hash("Admin@123"),   "admin",   "Admin",   "User",   true),
        new(2, "trainer@gym.com", Hash("Trainer@123"), "trainer", "Trainer", "User",   true),
        new(3, "client@gym.com",  Hash("Client@123"),  "client",  "Client",  "User",   true),
    ];

    private static readonly Dictionary<string, (ulong UserId, DateTime Expiry)> _refreshTokens = [];
    private static readonly Dictionary<string, (ulong UserId, DateTime Expiry)> _passwordResetTokens = [];
    private static readonly Dictionary<string, (string Otp, DateTime Expiry)> _otpStore = [];
    private static ulong _nextId = 4;

    public Task<AuthResponse?> RegisterAsync(RegisterRequest request)
    {
        if (_users.Any(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase)))
            return Task.FromResult<AuthResponse?>(null);

        var user = new SeedUser(_nextId++, request.Email, Hash(request.Password), request.Role, request.FirstName, request.LastName, false);
        _users.Add(user);
        return Task.FromResult<AuthResponse?>(GenerateTokens(user));
    }

    public Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u =>
            u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
            u.PasswordHash == Hash(request.Password));

        return Task.FromResult(user is null ? null : GenerateTokens(user));
    }

    public Task LogoutAsync(ulong userId)
    {
        var keys = _refreshTokens.Where(kv => kv.Value.UserId == userId).Select(kv => kv.Key).ToList();
        foreach (var k in keys) _refreshTokens.Remove(k);
        return Task.CompletedTask;
    }

    public Task<AuthResponse?> RefreshAsync(string refreshToken)
    {
        if (!_refreshTokens.TryGetValue(refreshToken, out var entry) || entry.Expiry < DateTime.UtcNow)
            return Task.FromResult<AuthResponse?>(null);

        _refreshTokens.Remove(refreshToken);
        var user = _users.FirstOrDefault(u => u.Id == entry.UserId);
        return Task.FromResult(user is null ? null : GenerateTokens(user));
    }

    public Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
        if (user is null) return Task.FromResult(false);
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        _passwordResetTokens[token] = (user.Id, DateTime.UtcNow.AddHours(1));
        // In production: send token via email
        return Task.FromResult(true);
    }

    public Task<bool> ResetPasswordAsync(ResetPasswordRequest request)
    {
        if (!_passwordResetTokens.TryGetValue(request.Token, out var entry) || entry.Expiry < DateTime.UtcNow)
            return Task.FromResult(false);

        var user = _users.FirstOrDefault(u => u.Id == entry.UserId);
        if (user is null) return Task.FromResult(false);

        _users.Remove(user);
        _users.Add(user with { PasswordHash = Hash(request.NewPassword) });
        _passwordResetTokens.Remove(request.Token);
        return Task.FromResult(true);
    }

    public Task<bool> ChangePasswordAsync(ulong userId, ChangePasswordRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId && u.PasswordHash == Hash(request.CurrentPassword));
        if (user is null) return Task.FromResult(false);
        _users.Remove(user);
        _users.Add(user with { PasswordHash = Hash(request.NewPassword) });
        return Task.FromResult(true);
    }

    public Task<UserProfileResponse?> GetMeAsync(ulong userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        if (user is null) return Task.FromResult<UserProfileResponse?>(null);
        return Task.FromResult<UserProfileResponse?>(new UserProfileResponse
        {
            UserId = user.Id, Email = user.Email, FirstName = user.FirstName,
            LastName = user.LastName, Role = user.Role, IsEmailVerified = user.IsEmailVerified
        });
    }

    public Task<bool> VerifyEmailAsync(VerifyEmailRequest request)
    {
        if (!_otpStore.TryGetValue(request.Email, out var entry) || entry.Expiry < DateTime.UtcNow || entry.Otp != request.Otp)
            return Task.FromResult(false);

        var user = _users.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
        if (user is null) return Task.FromResult(false);
        _users.Remove(user);
        _users.Add(user with { IsEmailVerified = true });
        _otpStore.Remove(request.Email);
        return Task.FromResult(true);
    }

    public Task<bool> ResendOtpAsync(ResendOtpRequest request)
    {
        var user = _users.FirstOrDefault(u => u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase));
        if (user is null) return Task.FromResult(false);
        var otp = Random.Shared.Next(100000, 999999).ToString();
        _otpStore[request.Email] = (otp, DateTime.UtcNow.AddMinutes(10));
        // In production: send via email/SMS based on request.Channel
        return Task.FromResult(true);
    }

    private AuthResponse GenerateTokens(SeedUser user)
    {
        var expiry = DateTime.UtcNow.AddMinutes(_jwt.AccessTokenExpiryMinutes);
        var accessToken = CreateJwt(user, expiry);
        var refreshToken = GenerateRefreshToken();
        _refreshTokens[refreshToken] = (user.Id, DateTime.UtcNow.AddDays(_jwt.RefreshTokenExpiryDays));
        return new AuthResponse { AccessToken = accessToken, RefreshToken = refreshToken, ExpiresAt = expiry, Role = user.Role, UserId = user.Id, Email = user.Email };
    }

    private string CreateJwt(SeedUser user, DateTime expiry)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var token = new JwtSecurityToken(issuer: _jwt.Issuer, audience: _jwt.Audience, claims: claims, expires: expiry, signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    private static string Hash(string input) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(input)));

    private record SeedUser(ulong Id, string Email, string PasswordHash, string Role, string FirstName, string LastName, bool IsEmailVerified);
}

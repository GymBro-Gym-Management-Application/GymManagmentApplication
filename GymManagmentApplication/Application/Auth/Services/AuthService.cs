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

    // Seeded in-memory users: email -> (passwordHash, role, userId)
    // Passwords: admin@gym.com/Admin@123, trainer@gym.com/Trainer@123, client@gym.com/Client@123
    private static readonly List<SeedUser> _users =
    [
        new(1, "admin@gym.com",   Hash("Admin@123"),   "admin"),
        new(2, "trainer@gym.com", Hash("Trainer@123"), "trainer"),
        new(3, "client@gym.com",  Hash("Client@123"),  "client"),
    ];

    // RefreshToken store: token -> (userId, expiry)
    private static readonly Dictionary<string, (ulong UserId, DateTime Expiry)> _refreshTokens = [];

    public Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        var user = _users.FirstOrDefault(u =>
            u.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase) &&
            u.PasswordHash == Hash(request.Password));

        if (user is null) return Task.FromResult<AuthResponse?>(null);

        var response = GenerateTokens(user);
        return Task.FromResult<AuthResponse?>(response);
    }

    public Task<AuthResponse?> RefreshAsync(string refreshToken)
    {
        if (!_refreshTokens.TryGetValue(refreshToken, out var entry) || entry.Expiry < DateTime.UtcNow)
            return Task.FromResult<AuthResponse?>(null);

        _refreshTokens.Remove(refreshToken);
        var user = _users.FirstOrDefault(u => u.Id == entry.UserId);
        if (user is null) return Task.FromResult<AuthResponse?>(null);

        return Task.FromResult<AuthResponse?>(GenerateTokens(user));
    }

    private AuthResponse GenerateTokens(SeedUser user)
    {
        var expiry = DateTime.UtcNow.AddMinutes(_jwt.AccessTokenExpiryMinutes);
        var accessToken = CreateJwt(user, expiry);
        var refreshToken = GenerateRefreshToken();

        _refreshTokens[refreshToken] = (user.Id, DateTime.UtcNow.AddDays(_jwt.RefreshTokenExpiryDays));

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            ExpiresAt = expiry,
            Role = user.Role,
            UserId = user.Id,
            Email = user.Email
        };
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

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: expiry,
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken() =>
        Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    private static string Hash(string input) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(input)));

    private record SeedUser(ulong Id, string Email, string PasswordHash, string Role);
}

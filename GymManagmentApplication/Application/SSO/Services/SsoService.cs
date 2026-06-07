using GymManagmentApplication.Application.Auth.Responses;
using GymManagmentApplication.Application.SSO.Interfaces;
using GymManagmentApplication.Application.SSO.Requests;
using GymManagmentApplication.Application.SSO.Responses;

namespace GymManagmentApplication.Application.SSO.Services;

public class SsoService : ISsoService
{
    private static readonly List<SsoProviderResponse> _providers =
    [
        new() { Id = "1", Provider = "Google",    ClientId = "google-client-id",    RedirectUri = "/auth/sso/callback", IsEnabled = true },
        new() { Id = "2", Provider = "Microsoft", ClientId = "microsoft-client-id", RedirectUri = "/auth/sso/callback", IsEnabled = true },
        new() { Id = "3", Provider = "Apple",     ClientId = "apple-client-id",     RedirectUri = "/auth/sso/callback", IsEnabled = false },
    ];

    public Task<SsoInitResponse> InitAsync(SsoInitRequest request)
    {
        var state = Guid.NewGuid().ToString("N");
        var authUrl = request.Provider.ToLower() switch
        {
            "google"    => $"https://accounts.google.com/o/oauth2/auth?state={state}&redirect_uri={Uri.EscapeDataString(request.RedirectUri)}",
            "microsoft" => $"https://login.microsoftonline.com/common/oauth2/v2.0/authorize?state={state}&redirect_uri={Uri.EscapeDataString(request.RedirectUri)}",
            "apple"     => $"https://appleid.apple.com/auth/authorize?state={state}&redirect_uri={Uri.EscapeDataString(request.RedirectUri)}",
            _           => throw new ArgumentException($"Unsupported provider: {request.Provider}")
        };
        return Task.FromResult(new SsoInitResponse { AuthorizationUrl = authUrl, State = state });
    }

    public Task<AuthResponse?> CallbackAsync(SsoCallbackRequest request)
    {
        // In production: exchange code with provider, validate, create/fetch user
        var response = new AuthResponse
        {
            AccessToken = "sso-access-token-placeholder",
            RefreshToken = "sso-refresh-token-placeholder",
            ExpiresAt = DateTime.UtcNow.AddHours(1),
            Role = "client",
            UserId = 0,
            Email = "sso-user@example.com"
        };
        return Task.FromResult<AuthResponse?>(response);
    }

    public Task<List<SsoProviderResponse>> GetProvidersAsync(ulong tenantId) =>
        Task.FromResult(_providers.ToList());

    public Task<SsoProviderResponse?> ConfigureProviderAsync(string id, ConfigureSsoProviderRequest request)
    {
        var provider = _providers.FirstOrDefault(p => p.Id == id);
        if (provider is null) return Task.FromResult<SsoProviderResponse?>(null);
        provider.ClientId = request.ClientId;
        provider.RedirectUri = request.RedirectUri;
        provider.IsEnabled = request.IsEnabled;
        return Task.FromResult<SsoProviderResponse?>(provider);
    }

    public Task<bool> DeleteProviderAsync(string id)
    {
        var provider = _providers.FirstOrDefault(p => p.Id == id);
        if (provider is null) return Task.FromResult(false);
        _providers.Remove(provider);
        return Task.FromResult(true);
    }
}

using GymManagmentApplication.Application.Auth.Requests;
using GymManagmentApplication.Application.Auth.Responses;

namespace GymManagmentApplication.Application.Auth.Interfaces;

public interface IAuthService
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);
    Task<AuthResponse?> RefreshAsync(string refreshToken);
}

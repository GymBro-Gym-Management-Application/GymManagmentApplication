using FluentValidation;
using GymManagmentApplication.Application.Auth.Interfaces;
using GymManagmentApplication.Application.Auth.Requests;
using GymManagmentApplication.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService service, IValidator<LoginRequest> validator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponse<object>>> Login([FromBody] LoginRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid)
            return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));

        var result = await service.LoginAsync(request);
        if (result is null)
            return Unauthorized(ApiResponse<object>.Fail("Invalid email or password."));

        return Ok(ApiResponse<object>.Ok(result, "Login successful."));
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<ApiResponse<object>>> Refresh([FromBody] RefreshTokenRequest request)
    {
        var result = await service.RefreshAsync(request.RefreshToken);
        if (result is null)
            return Unauthorized(ApiResponse<object>.Fail("Invalid or expired refresh token."));

        return Ok(ApiResponse<object>.Ok(result, "Token refreshed."));
    }
}

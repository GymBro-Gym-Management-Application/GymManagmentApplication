using System.Security.Claims;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Health.Interfaces;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/health")]
[RequireModule("stats")]
public class HealthController(IHealthService service) : ControllerBase
{
    private ulong UserId => ulong.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

    [HttpGet("today")]
    [AuthorizeRoles("admin", "trainer", "client")]
    public async Task<ActionResult<ApiResponse<object>>> GetToday()
        => Ok(ApiResponse<object>.Ok(await service.GetTodayAsync(UserId)));
}

using System.Security.Claims;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.UserModules.Interfaces;
using GymManagmentApplication.Application.UserModules.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api")]
public class UserModulesController(IUserModulesService service) : ControllerBase
{
    private ulong CurrentUserId => ulong.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");
    private bool IsAdmin => string.Equals(User.FindFirstValue(ClaimTypes.Role), "admin", StringComparison.OrdinalIgnoreCase);

    /// <summary>List all gate-able feature modules (admin-only, for the assignment UI).</summary>
    [HttpGet("modules")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> GetModules()
        => Ok(ApiResponse<object>.Ok(await service.GetAllModulesAsync()));

    /// <summary>A user's current module access — admin can view anyone's, a user can view their own.</summary>
    [HttpGet("users/{id}/modules")]
    [AuthorizeRoles("admin", "trainer", "client")]
    public async Task<ActionResult<ApiResponse<object>>> GetUserModules(ulong id)
    {
        if (!IsAdmin && id != CurrentUserId)
            return Forbid();

        return Ok(ApiResponse<object>.Ok(await service.GetUserModulesAsync(id)));
    }

    /// <summary>Bulk update which modules are enabled for a given Trainer or Client (admin-only).</summary>
    [HttpPut("users/{id}/modules")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> SetUserModules(ulong id, [FromBody] UpdateUserModulesRequest request)
    {
        var result = await service.SetUserModulesAsync(id, CurrentUserId, request);
        return Ok(ApiResponse<object>.Ok(result, "Module access updated."));
    }
}

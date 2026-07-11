using System.Security.Claims;
using GymManagmentApplication.Application.Challenges.Interfaces;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/challenges")]
[RequireModule("challenges")]
public class ChallengesController(IChallengesService service) : ControllerBase
{
    private ulong UserId => ulong.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "0");

    [HttpGet("active")]
    [AuthorizeRoles("admin", "trainer", "client")]
    public async Task<ActionResult<ApiResponse<object>>> GetActive()
        => Ok(ApiResponse<object>.Ok(await service.GetActiveAsync(UserId)));
}

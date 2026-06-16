using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Subscription.Interfaces;
using GymManagmentApplication.Application.Subscription.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/subscriptions")]
[AuthorizeRoles("admin", "trainer", "client")]
public class SubscriptionController(
    ISubscriptionService service,
    IValidator<CreateSubscriptionRequest> validator) : ControllerBase
{
    [HttpGet]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> GetAll([FromQuery] SubscriptionListRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetAllAsync(request)));

    [HttpPost]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateSubscriptionRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        var result = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<object>.Ok(result, "Subscription created."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPut("{id}/renew")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Renew(ulong id, [FromBody] RenewSubscriptionRequest request)
    {
        var result = await service.RenewAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Subscription renewed."));
    }

    [HttpPost("{id}/upgrade")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Upgrade(ulong id, [FromBody] UpgradeSubscriptionRequest request)
    {
        var result = await service.UpgradeAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Subscription upgraded."));
    }

    [HttpPost("{id}/downgrade")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Downgrade(ulong id, [FromBody] DowngradeSubscriptionRequest request)
    {
        var result = await service.DowngradeAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Subscription downgraded."));
    }

    [HttpPost("{id}/freeze")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Freeze(ulong id, [FromBody] FreezeSubscriptionRequest request)
    {
        var result = await service.FreezeAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Subscription frozen."));
    }

    [HttpPost("{id}/unfreeze")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Unfreeze(ulong id)
    {
        var result = await service.UnfreezeAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Subscription reactivated."));
    }

    [HttpDelete("{id}/cancel")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> Cancel(ulong id)
    {
        var ok = await service.CancelAsync(id);
        return ok ? Ok(ApiResponse<object>.Ok((object)null!, "Subscription cancelled.")) : NotFound(ApiResponse<object>.Fail($"Subscription {id} not found."));
    }

    [HttpGet("{id}/usage")]
    public async Task<ActionResult<ApiResponse<object>>> GetUsage(ulong id)
    {
        var result = await service.GetUsageAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Subscription {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }
}

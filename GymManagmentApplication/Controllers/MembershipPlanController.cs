using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.MembershipPlan.Interfaces;
using GymManagmentApplication.Application.MembershipPlan.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/membership-plans")]
[AuthorizeRoles("admin")]
public class MembershipPlanController(
    IMembershipPlanService service,
    IValidator<CreateMembershipPlanRequest> validator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<object>>> GetAll([FromQuery] MembershipPlanListRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetAllAsync(request)));

    [HttpPost]
    public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateMembershipPlanRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        var result = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<object>.Ok(result, "Membership plan created."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Plan {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(ulong id, [FromBody] UpdateMembershipPlanRequest request)
    {
        var result = await service.UpdateAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Plan {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Plan updated."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> Delete(ulong id)
    {
        var ok = await service.DeleteAsync(id);
        return ok ? Ok(ApiResponse<object>.Ok((object)null!, "Plan archived.")) : NotFound(ApiResponse<object>.Fail($"Plan {id} not found."));
    }

    [HttpGet("{id}/features")]
    public async Task<ActionResult<ApiResponse<object>>> GetFeatures(ulong id)
        => Ok(ApiResponse<object>.Ok(await service.GetFeaturesAsync(id)));

    [HttpPut("{id}/features")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateFeatures(ulong id, [FromBody] UpdatePlanFeaturesRequest request)
    {
        var result = await service.UpdateFeaturesAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Plan {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Features updated."));
    }
}

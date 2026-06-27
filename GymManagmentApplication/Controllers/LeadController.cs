using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Lead.Interfaces;
using GymManagmentApplication.Application.Lead.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/leads")]
[AuthorizeRoles("admin", "trainer")]
public class LeadController(ILeadService service, IValidator<CreateLeadRequest> validator) : ControllerBase
{
    [HttpGet]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> GetAll([FromQuery] LeadListRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetAllAsync(request)));

    [HttpPost]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateLeadRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        var result = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<object>.Ok(result, "Lead created."));
    }

    [HttpGet("{id}")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Lead {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPut("{id}")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> Update(ulong id, [FromBody] UpdateLeadRequest request)
    {
        var result = await service.UpdateAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Lead {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPost("{id}/convert")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> Convert(ulong id)
    {
        var result = await service.ConvertAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Lead {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Lead converted to member."));
    }

    [HttpGet("{id}/score")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> GetScore(ulong id)
    {
        var result = await service.GetScoreAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Lead {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPost("{id}/followup")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> AddFollowup(ulong id, [FromBody] LeadFollowupRequest request)
        => Ok(ApiResponse<object>.Ok(await service.AddFollowupAsync(id, request)));

    [HttpGet("sources")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> GetSources([FromQuery] ulong tenantId)
        => Ok(ApiResponse<object>.Ok(await service.GetSourceBreakdownAsync(tenantId)));

    [HttpPost("import")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> BulkImport([FromBody] BulkImportLeadRequest request)
        => Ok(ApiResponse<object>.Ok(await service.BulkImportAsync(request)));
}

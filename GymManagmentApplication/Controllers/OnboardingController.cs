using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Onboarding.Interfaces;
using GymManagmentApplication.Application.Onboarding.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/onboarding")]
[AuthorizeRoles("admin", "trainer", "client")]
public class OnboardingController(IOnboardingService service, IValidator<StartOnboardingRequest> validator) : ControllerBase
{
    [HttpPost("start")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> Start([FromBody] StartOnboardingRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        return Ok(ApiResponse<object>.Ok(await service.StartAsync(request), "Onboarding started."));
    }

    [HttpGet("{id}/status")]
    [AuthorizeRoles("admin", "trainer", "client")]
    public async Task<ActionResult<ApiResponse<object>>> GetStatus(ulong id)
    {
        var result = await service.GetStatusAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Onboarding for member {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPut("{id}/step")]
    [AuthorizeRoles("admin", "trainer", "client")]
    public async Task<ActionResult<ApiResponse<object>>> SubmitStep(ulong id, [FromBody] SubmitOnboardingStepRequest request)
    {
        var result = await service.SubmitStepAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Step '{request.StepKey}' not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPost("assessments")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> SubmitAssessment([FromBody] SubmitAssessmentRequest request)
        => Ok(ApiResponse<object>.Ok(await service.SubmitAssessmentAsync(request)));

    [HttpGet("templates")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> GetTemplates([FromQuery] ulong tenantId)
        => Ok(ApiResponse<object>.Ok(await service.GetTemplatesAsync(tenantId)));

    [HttpPost("templates")]
    [AuthorizeRoles("admin")]
    public async Task<ActionResult<ApiResponse<object>>> CreateTemplate([FromBody] CreateOnboardingTemplateRequest request)
        => Ok(ApiResponse<object>.Ok(await service.CreateTemplateAsync(request), "Template created."));

    [HttpPost("{id}/complete")]
    [AuthorizeRoles("admin", "trainer")]
    public async Task<ActionResult<ApiResponse<object>>> Complete(ulong id)
    {
        var result = await service.CompleteAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Onboarding for member {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Onboarding completed."));
    }
}

using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Pricing.Interfaces;
using GymManagmentApplication.Application.Pricing.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/pricing")]
[AuthorizeRoles("admin")]
public class PricingController(
    IPricingService service,
    IValidator<CreatePricingRuleRequest> ruleValidator,
    IValidator<CreateDiscountRequest> discountValidator) : ControllerBase
{
    [HttpGet("rules")]
    public async Task<ActionResult<ApiResponse<object>>> GetRules([FromQuery] PricingRuleListRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetRulesAsync(request)));

    [HttpPost("rules")]
    public async Task<ActionResult<ApiResponse<object>>> CreateRule([FromBody] CreatePricingRuleRequest request)
    {
        var v = await ruleValidator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        return Ok(ApiResponse<object>.Ok(await service.CreateRuleAsync(request), "Pricing rule created."));
    }

    [HttpPut("rules/{id}")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateRule(ulong id, [FromBody] UpdatePricingRuleRequest request)
    {
        var result = await service.UpdateRuleAsync(id, request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Rule {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Rule updated."));
    }

    [HttpDelete("rules/{id}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteRule(ulong id)
    {
        var ok = await service.DeleteRuleAsync(id);
        return ok ? Ok(ApiResponse<object>.Ok((object)null!, "Rule deleted.")) : NotFound(ApiResponse<object>.Fail($"Rule {id} not found."));
    }

    [HttpGet("calculate")]
    public async Task<ActionResult<ApiResponse<object>>> Calculate([FromQuery] CalculatePriceRequest request)
        => Ok(ApiResponse<object>.Ok(await service.CalculateAsync(request)));

    [HttpGet("discounts")]
    public async Task<ActionResult<ApiResponse<object>>> GetDiscounts([FromQuery] ulong tenantId)
        => Ok(ApiResponse<object>.Ok(await service.GetDiscountsAsync(tenantId)));

    [HttpPost("discounts")]
    public async Task<ActionResult<ApiResponse<object>>> CreateDiscount([FromBody] CreateDiscountRequest request)
    {
        var v = await discountValidator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        return Ok(ApiResponse<object>.Ok(await service.CreateDiscountAsync(request), "Discount code created."));
    }

    [HttpPost("discounts/validate")]
    public async Task<ActionResult<ApiResponse<object>>> ValidateDiscount([FromBody] ValidateDiscountRequest request)
        => Ok(ApiResponse<object>.Ok(await service.ValidateDiscountAsync(request)));
}

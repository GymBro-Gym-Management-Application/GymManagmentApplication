using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Payment.Interfaces;
using GymManagmentApplication.Application.Payment.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/payments")]
[AuthorizeRoles("admin")]
public class PaymentController(
    IPaymentService service,
    IValidator<ChargePaymentRequest> chargeValidator,
    IValidator<RefundPaymentRequest> refundValidator) : ControllerBase
{
    [HttpPost("charge")]
    public async Task<ActionResult<ApiResponse<object>>> Charge([FromBody] ChargePaymentRequest request)
    {
        var v = await chargeValidator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        return Ok(ApiResponse<object>.Ok(await service.ChargeAsync(request), "Payment processed."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Payment {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpPost("refund")]
    public async Task<ActionResult<ApiResponse<object>>> Refund([FromBody] RefundPaymentRequest request)
    {
        var v = await refundValidator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        var result = await service.RefundAsync(request);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Payment {request.PaymentId} not found.")) : Ok(ApiResponse<object>.Ok(result, "Refund processed."));
    }

    [HttpGet("history")]
    public async Task<ActionResult<ApiResponse<object>>> GetHistory([FromQuery] PaymentHistoryRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetHistoryAsync(request)));

    [HttpPost("methods")]
    public async Task<ActionResult<ApiResponse<object>>> SaveMethod([FromBody] SavePaymentMethodRequest request)
        => Ok(ApiResponse<object>.Ok(await service.SaveMethodAsync(request), "Payment method saved."));

    [HttpGet("methods")]
    public async Task<ActionResult<ApiResponse<object>>> GetMethods([FromQuery] ulong userId)
        => Ok(ApiResponse<object>.Ok(await service.GetMethodsAsync(userId)));

    [HttpDelete("methods/{id}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteMethod(string id)
    {
        var ok = await service.DeleteMethodAsync(id);
        return ok ? Ok(ApiResponse<object>.Ok((object)null!, "Payment method removed.")) : NotFound(ApiResponse<object>.Fail("Method not found."));
    }

    [HttpPost("intent")]
    public async Task<ActionResult<ApiResponse<object>>> CreateIntent([FromBody] CreatePaymentIntentRequest request)
        => Ok(ApiResponse<object>.Ok(await service.CreateIntentAsync(request)));

    [HttpPost("reminders")]
    public async Task<ActionResult<ApiResponse<object>>> SendReminder([FromBody] SendPaymentReminderRequest request)
    {
        await service.SendReminderAsync(request);
        return Ok(ApiResponse<object>.Ok((object)null!, "Reminder sent."));
    }
}

using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Invoice.Interfaces;
using GymManagmentApplication.Application.Invoice.Requests;
using GymManagmentApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/invoices")]
[AuthorizeRoles("admin")]
public class InvoiceController(
    IInvoiceService service,
    IValidator<CreateInvoiceRequest> validator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ApiResponse<object>>> GetAll([FromQuery] InvoiceListRequest request)
        => Ok(ApiResponse<object>.Ok(await service.GetAllAsync(request)));

    [HttpPost]
    public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateInvoiceRequest request)
    {
        var v = await validator.ValidateAsync(request);
        if (!v.IsValid) return BadRequest(ApiResponse<object>.Fail("Validation failed.", v.Errors.Select(e => e.ErrorMessage).ToList()));
        var result = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<object>.Ok(result, "Invoice generated."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Invoice {id} not found.")) : Ok(ApiResponse<object>.Ok(result));
    }

    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> GetPdf(ulong id)
    {
        var pdf = await service.GetPdfAsync(id);
        if (pdf.Length == 0) return NotFound();
        return File(pdf, "application/pdf", $"invoice-{id}.pdf");
    }

    [HttpPost("{id}/send")]
    public async Task<ActionResult<ApiResponse<object>>> Send(ulong id)
    {
        var ok = await service.SendAsync(id);
        return ok ? Ok(ApiResponse<object>.Ok((object)null!, "Invoice sent.")) : NotFound(ApiResponse<object>.Fail($"Invoice {id} not found."));
    }

    [HttpPut("{id}/mark-paid")]
    public async Task<ActionResult<ApiResponse<object>>> MarkPaid(ulong id)
    {
        var result = await service.MarkPaidAsync(id);
        return result is null ? NotFound(ApiResponse<object>.Fail($"Invoice {id} not found.")) : Ok(ApiResponse<object>.Ok(result, "Invoice marked as paid."));
    }
}

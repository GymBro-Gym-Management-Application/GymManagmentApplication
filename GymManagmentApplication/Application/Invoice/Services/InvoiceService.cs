using System.Text;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Invoice.Interfaces;
using GymManagmentApplication.Application.Invoice.Requests;
using GymManagmentApplication.Application.Invoice.Responses;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Repositories.Invoice;

namespace GymManagmentApplication.Application.Invoice.Services;

public class InvoiceService(IInvoiceRepository repository) : IInvoiceService
{
    public async Task<PagedResponse<InvoiceResponse>> GetAllAsync(InvoiceListRequest request)
    {
        var (items, total) = await repository.GetAllAsync(request);
        return new PagedResponse<InvoiceResponse>
        {
            Items = items.Select(Map),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public async Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request)
    {
        var total = request.Subtotal + request.Tax - request.Discount;
        var invoice = new Domain.Entities.Billing.Invoice
        {
            TenantId = request.TenantId,
            UserId = request.UserId,
            MembershipId = request.MembershipId,
            InvoiceNo = $"INV-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}",
            Subtotal = request.Subtotal,
            Tax = request.Tax,
            Discount = request.Discount,
            Total = total,
            Currency = request.Currency,
            DueDate = request.DueDate,
            Notes = request.Notes,
            Status = InvoiceStatus.Draft
        };
        return Map(await repository.CreateAsync(invoice));
    }

    public async Task<InvoiceResponse?> GetByIdAsync(ulong id)
    {
        var i = await repository.GetByIdAsync(id);
        return i is null ? null : Map(i);
    }

    public async Task<byte[]> GetPdfAsync(ulong id)
    {
        var i = await repository.GetByIdAsync(id);
        if (i is null) return [];
        var content = $"INVOICE {i.InvoiceNo}\nTotal: {i.Currency} {i.Total}\nStatus: {i.Status}";
        return Encoding.UTF8.GetBytes(content);
    }

    public async Task<bool> SendAsync(ulong id)
    {
        var i = await repository.GetByIdAsync(id);
        if (i is null) return false;
        i.Status = InvoiceStatus.Sent;
        await repository.UpdateAsync(i);
        return true;
    }

    public async Task<InvoiceResponse?> MarkPaidAsync(ulong id)
    {
        var i = await repository.GetByIdAsync(id);
        if (i is null) return null;
        i.Status = InvoiceStatus.Paid;
        i.PaidAt = DateTime.UtcNow;
        await repository.UpdateAsync(i);
        return Map(i);
    }

    private static InvoiceResponse Map(Domain.Entities.Billing.Invoice i) => new()
    {
        Id = i.Id, TenantId = i.TenantId, UserId = i.UserId,
        InvoiceNo = i.InvoiceNo, Status = i.Status.ToString(),
        Subtotal = i.Subtotal, Tax = i.Tax, Discount = i.Discount,
        Total = i.Total, Currency = i.Currency, DueDate = i.DueDate,
        PaidAt = i.PaidAt, CreatedAt = i.CreatedAt
    };
}

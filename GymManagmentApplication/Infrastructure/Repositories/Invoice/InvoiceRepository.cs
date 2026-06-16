using GymManagmentApplication.Application.Invoice.Requests;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.Invoice;

public interface IInvoiceRepository
{
    Task<(List<Domain.Entities.Billing.Invoice> Items, int Total)> GetAllAsync(InvoiceListRequest request);
    Task<Domain.Entities.Billing.Invoice> CreateAsync(Domain.Entities.Billing.Invoice invoice);
    Task<Domain.Entities.Billing.Invoice?> GetByIdAsync(ulong id);
    Task<Domain.Entities.Billing.Invoice?> UpdateAsync(Domain.Entities.Billing.Invoice invoice);
}

public class InvoiceRepository : IInvoiceRepository
{
    private static readonly List<Domain.Entities.Billing.Invoice> _store = [];
    private static ulong _id = 1;

    public Task<(List<Domain.Entities.Billing.Invoice> Items, int Total)> GetAllAsync(InvoiceListRequest request)
    {
        var q = _store.AsEnumerable();
        if (request.TenantId.HasValue) q = q.Where(i => i.TenantId == request.TenantId);
        if (!string.IsNullOrWhiteSpace(request.Status) && Enum.TryParse<InvoiceStatus>(request.Status, true, out var s))
            q = q.Where(i => i.Status == s);
        var total = q.Count();
        var items = q.OrderByDescending(i => i.CreatedAt).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<Domain.Entities.Billing.Invoice> CreateAsync(Domain.Entities.Billing.Invoice invoice)
    {
        invoice.Id = _id++;
        invoice.CreatedAt = DateTime.UtcNow;
        invoice.UpdatedAt = DateTime.UtcNow;
        _store.Add(invoice);
        return Task.FromResult(invoice);
    }

    public Task<Domain.Entities.Billing.Invoice?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(i => i.Id == id));

    public Task<Domain.Entities.Billing.Invoice?> UpdateAsync(Domain.Entities.Billing.Invoice invoice)
    {
        invoice.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult<Domain.Entities.Billing.Invoice?>(invoice);
    }
}

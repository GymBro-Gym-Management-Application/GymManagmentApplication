using GymManagmentApplication.Application.Payment.Requests;
using GymManagmentApplication.Domain.Entities.Billing;

namespace GymManagmentApplication.Infrastructure.Repositories.Payment;

public interface IPaymentRepository
{
    Task<Domain.Entities.Billing.Payment> CreateAsync(Domain.Entities.Billing.Payment payment);
    Task<Domain.Entities.Billing.Payment?> GetByIdAsync(ulong id);
    Task<(List<Domain.Entities.Billing.Payment> Items, int Total)> GetHistoryAsync(PaymentHistoryRequest request);
}

public class PaymentRepository : IPaymentRepository
{
    private static readonly List<Domain.Entities.Billing.Payment> _store = [];
    private static ulong _id = 1;

    public Task<Domain.Entities.Billing.Payment> CreateAsync(Domain.Entities.Billing.Payment payment)
    {
        payment.Id = _id++;
        payment.CreatedAt = DateTime.UtcNow;
        _store.Add(payment);
        return Task.FromResult(payment);
    }

    public Task<Domain.Entities.Billing.Payment?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(p => p.Id == id));

    public Task<(List<Domain.Entities.Billing.Payment> Items, int Total)> GetHistoryAsync(PaymentHistoryRequest request)
    {
        var q = _store.AsEnumerable();
        if (request.TenantId.HasValue) q = q.Where(p => p.TenantId == request.TenantId);
        var total = q.Count();
        var items = q.OrderByDescending(p => p.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }
}

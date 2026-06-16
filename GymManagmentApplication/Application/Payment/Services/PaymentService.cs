using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Payment.Interfaces;
using GymManagmentApplication.Application.Payment.Requests;
using GymManagmentApplication.Application.Payment.Responses;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Repositories.Payment;

namespace GymManagmentApplication.Application.Payment.Services;

public class PaymentService(IPaymentRepository repository) : IPaymentService
{
    private static readonly List<PaymentMethodResponse> _methods = [];
    private static int _methodSeq = 1;

    public async Task<PaymentResponse> ChargeAsync(ChargePaymentRequest request)
    {
        var payment = new Domain.Entities.Billing.Payment
        {
            TenantId = request.TenantId,
            InvoiceId = request.InvoiceId,
            Amount = request.Amount,
            Currency = request.Currency,
            Method = request.Method,
            GatewayId = request.GatewayId,
            Status = PaymentStatus.Completed,
            GatewayRef = $"REF-{Guid.NewGuid():N}"[..16]
        };
        return Map(await repository.CreateAsync(payment));
    }

    public async Task<PaymentResponse?> GetByIdAsync(ulong id)
    {
        var p = await repository.GetByIdAsync(id);
        return p is null ? null : Map(p);
    }

    public async Task<RefundResponse?> RefundAsync(RefundPaymentRequest request)
    {
        var p = await repository.GetByIdAsync(request.PaymentId);
        if (p is null) return null;
        var refundAmount = request.Amount ?? p.Amount;
        p.Status = PaymentStatus.Refunded;
        return new RefundResponse
        {
            OriginalPaymentId = p.Id,
            RefundedAmount = refundAmount,
            Status = "Refunded",
            RefundedAt = DateTime.UtcNow
        };
    }

    public async Task<PagedResponse<PaymentResponse>> GetHistoryAsync(PaymentHistoryRequest request)
    {
        var (items, total) = await repository.GetHistoryAsync(request);
        return new PagedResponse<PaymentResponse>
        {
            Items = items.Select(Map),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public Task<PaymentMethodResponse> SaveMethodAsync(SavePaymentMethodRequest request)
    {
        var method = new PaymentMethodResponse
        {
            Id = (_methodSeq++).ToString(),
            UserId = request.UserId,
            Provider = request.Provider,
            MaskedInfo = $"****-{request.Token[^4..]}",
            IsDefault = request.IsDefault
        };
        if (request.IsDefault)
            _methods.Where(m => m.UserId == request.UserId).ToList().ForEach(m => m.IsDefault = false);
        _methods.Add(method);
        return Task.FromResult(method);
    }

    public Task<List<PaymentMethodResponse>> GetMethodsAsync(ulong userId) =>
        Task.FromResult(_methods.Where(m => m.UserId == userId).ToList());

    public Task<bool> DeleteMethodAsync(string id)
    {
        var m = _methods.FirstOrDefault(x => x.Id == id);
        if (m is null) return Task.FromResult(false);
        _methods.Remove(m);
        return Task.FromResult(true);
    }

    public Task<PaymentIntentResponse> CreateIntentAsync(CreatePaymentIntentRequest request) =>
        Task.FromResult(new PaymentIntentResponse
        {
            IntentId = $"pi_{Guid.NewGuid():N}",
            ClientSecret = $"pi_{Guid.NewGuid():N}_secret_{Guid.NewGuid():N}",
            Amount = request.Amount,
            Currency = request.Currency,
            Provider = request.Provider
        });

    public Task<bool> SendReminderAsync(SendPaymentReminderRequest request) =>
        Task.FromResult(true);

    private static PaymentResponse Map(Domain.Entities.Billing.Payment p) => new()
    {
        Id = p.Id, TenantId = p.TenantId, InvoiceId = p.InvoiceId,
        Amount = p.Amount, Currency = p.Currency,
        Method = p.Method.ToString(), Status = p.Status.ToString(),
        GatewayRef = p.GatewayRef, CreatedAt = p.CreatedAt
    };
}

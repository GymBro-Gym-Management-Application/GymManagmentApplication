using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Payment.Requests;
using GymManagmentApplication.Application.Payment.Responses;

namespace GymManagmentApplication.Application.Payment.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponse> ChargeAsync(ChargePaymentRequest request);
    Task<PaymentResponse?> GetByIdAsync(ulong id);
    Task<RefundResponse?> RefundAsync(RefundPaymentRequest request);
    Task<PagedResponse<PaymentResponse>> GetHistoryAsync(PaymentHistoryRequest request);
    Task<PaymentMethodResponse> SaveMethodAsync(SavePaymentMethodRequest request);
    Task<List<PaymentMethodResponse>> GetMethodsAsync(ulong userId);
    Task<bool> DeleteMethodAsync(string id);
    Task<PaymentIntentResponse> CreateIntentAsync(CreatePaymentIntentRequest request);
    Task<bool> SendReminderAsync(SendPaymentReminderRequest request);
}

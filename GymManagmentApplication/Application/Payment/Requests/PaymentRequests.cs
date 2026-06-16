using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Application.Payment.Requests;

public class ChargePaymentRequest
{
    public ulong TenantId { get; set; }
    public ulong InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public PaymentMethod Method { get; set; }
    public ulong? GatewayId { get; set; }
}

public class RefundPaymentRequest
{
    public ulong PaymentId { get; set; }
    public decimal? Amount { get; set; }
    public string? Reason { get; set; }
}

public class SavePaymentMethodRequest
{
    public ulong UserId { get; set; }
    public string Provider { get; set; } = default!;
    public string Token { get; set; } = default!;
    public bool IsDefault { get; set; }
}

public class CreatePaymentIntentRequest
{
    public ulong TenantId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "USD";
    public string Provider { get; set; } = "stripe";
}

public class SendPaymentReminderRequest
{
    public ulong InvoiceId { get; set; }
    public string? Message { get; set; }
}

public class PaymentHistoryRequest
{
    public ulong? TenantId { get; set; }
    public ulong? UserId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

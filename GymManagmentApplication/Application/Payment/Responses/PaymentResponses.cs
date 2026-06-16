namespace GymManagmentApplication.Application.Payment.Responses;

public class PaymentResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public ulong InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = default!;
    public string Method { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string? GatewayRef { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PaymentMethodResponse
{
    public string Id { get; set; } = default!;
    public ulong UserId { get; set; }
    public string Provider { get; set; } = default!;
    public string MaskedInfo { get; set; } = default!;
    public bool IsDefault { get; set; }
}

public class PaymentIntentResponse
{
    public string ClientSecret { get; set; } = default!;
    public string IntentId { get; set; } = default!;
    public decimal Amount { get; set; }
    public string Currency { get; set; } = default!;
    public string Provider { get; set; } = default!;
}

public class RefundResponse
{
    public ulong OriginalPaymentId { get; set; }
    public decimal RefundedAmount { get; set; }
    public string Status { get; set; } = default!;
    public DateTime RefundedAt { get; set; }
}

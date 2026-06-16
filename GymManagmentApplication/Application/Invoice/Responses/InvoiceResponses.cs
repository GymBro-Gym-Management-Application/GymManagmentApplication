namespace GymManagmentApplication.Application.Invoice.Responses;

public class InvoiceResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public ulong UserId { get; set; }
    public string InvoiceNo { get; set; } = default!;
    public string Status { get; set; } = default!;
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
    public string Currency { get; set; } = default!;
    public DateOnly? DueDate { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

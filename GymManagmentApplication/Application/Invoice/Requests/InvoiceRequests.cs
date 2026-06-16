namespace GymManagmentApplication.Application.Invoice.Requests;

public class CreateInvoiceRequest
{
    public ulong TenantId { get; set; }
    public ulong UserId { get; set; }
    public ulong? MembershipId { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public string Currency { get; set; } = "USD";
    public DateOnly? DueDate { get; set; }
    public string? Notes { get; set; }
}

public class InvoiceListRequest
{
    public ulong? TenantId { get; set; }
    public string? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

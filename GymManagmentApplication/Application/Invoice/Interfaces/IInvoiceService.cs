using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Invoice.Requests;
using GymManagmentApplication.Application.Invoice.Responses;

namespace GymManagmentApplication.Application.Invoice.Interfaces;

public interface IInvoiceService
{
    Task<PagedResponse<InvoiceResponse>> GetAllAsync(InvoiceListRequest request);
    Task<InvoiceResponse> CreateAsync(CreateInvoiceRequest request);
    Task<InvoiceResponse?> GetByIdAsync(ulong id);
    Task<byte[]> GetPdfAsync(ulong id);
    Task<bool> SendAsync(ulong id);
    Task<InvoiceResponse?> MarkPaidAsync(ulong id);
}

namespace GymManagmentApplication.Application.Lead.Requests;

public class LeadListRequest
{
    public string? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

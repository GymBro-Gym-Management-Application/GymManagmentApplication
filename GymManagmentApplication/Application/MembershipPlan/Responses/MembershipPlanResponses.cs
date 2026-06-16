namespace GymManagmentApplication.Application.MembershipPlan.Responses;

public class MembershipPlanResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public ulong? BranchId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string BillingCycle { get; set; } = default!;
    public decimal Price { get; set; }
    public string Currency { get; set; } = default!;
    public byte TrialDays { get; set; }
    public uint? MaxMembers { get; set; }
    public bool IsActive { get; set; }
    public List<string> Features { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}

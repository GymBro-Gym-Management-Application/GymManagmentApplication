using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Application.MembershipPlan.Requests;

public class CreateMembershipPlanRequest
{
    public ulong TenantId { get; set; }
    public ulong? BranchId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public BillingCycle BillingCycle { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = "USD";
    public byte TrialDays { get; set; }
    public uint? MaxMembers { get; set; }
    public List<string>? Features { get; set; }
}

public class UpdateMembershipPlanRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public byte? TrialDays { get; set; }
    public uint? MaxMembers { get; set; }
    public bool? IsActive { get; set; }
}

public class UpdatePlanFeaturesRequest
{
    public List<string> Features { get; set; } = [];
}

public class MembershipPlanListRequest
{
    public ulong? TenantId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

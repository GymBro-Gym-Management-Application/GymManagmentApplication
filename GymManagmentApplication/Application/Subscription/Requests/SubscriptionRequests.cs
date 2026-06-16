namespace GymManagmentApplication.Application.Subscription.Requests;

public class CreateSubscriptionRequest
{
    public ulong TenantId { get; set; }
    public ulong UserId { get; set; }
    public ulong PlanId { get; set; }
    public ulong? BranchId { get; set; }
    public DateOnly StartsAt { get; set; }
    public bool AutoRenew { get; set; } = true;
    public string? Notes { get; set; }
}

public class RenewSubscriptionRequest
{
    public DateOnly? NewEndsAt { get; set; }
}

public class UpgradeSubscriptionRequest
{
    public ulong NewPlanId { get; set; }
}

public class DowngradeSubscriptionRequest
{
    public ulong NewPlanId { get; set; }
}

public class FreezeSubscriptionRequest
{
    public DateTime FreezeUntil { get; set; }
    public string? Reason { get; set; }
}

public class SubscriptionListRequest
{
    public ulong? TenantId { get; set; }
    public string? Status { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

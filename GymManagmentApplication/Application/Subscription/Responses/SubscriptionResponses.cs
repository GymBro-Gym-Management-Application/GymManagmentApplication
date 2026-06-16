namespace GymManagmentApplication.Application.Subscription.Responses;

public class SubscriptionResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public ulong UserId { get; set; }
    public ulong PlanId { get; set; }
    public string Status { get; set; } = default!;
    public DateOnly StartsAt { get; set; }
    public DateOnly? EndsAt { get; set; }
    public bool AutoRenew { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class SubscriptionUsageResponse
{
    public ulong SubscriptionId { get; set; }
    public int ClassesAttended { get; set; }
    public int WorkoutsCompleted { get; set; }
    public int PtSessionsUsed { get; set; }
    public int DaysActive { get; set; }
}

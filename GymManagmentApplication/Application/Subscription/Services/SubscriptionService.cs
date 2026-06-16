using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Subscription.Interfaces;
using GymManagmentApplication.Application.Subscription.Requests;
using GymManagmentApplication.Application.Subscription.Responses;
using GymManagmentApplication.Domain.Entities.Membership;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Repositories.Subscription;

namespace GymManagmentApplication.Application.Subscription.Services;

public class SubscriptionService(ISubscriptionRepository repository) : ISubscriptionService
{
    public async Task<PagedResponse<SubscriptionResponse>> GetAllAsync(SubscriptionListRequest request)
    {
        var (items, total) = await repository.GetAllAsync(request);
        return new PagedResponse<SubscriptionResponse>
        {
            Items = items.Select(Map),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public async Task<SubscriptionResponse> CreateAsync(CreateSubscriptionRequest request)
    {
        var m = new GymMembership
        {
            TenantId = request.TenantId,
            UserId = request.UserId,
            PlanId = request.PlanId,
            BranchId = request.BranchId,
            StartsAt = request.StartsAt,
            AutoRenew = request.AutoRenew,
            Notes = request.Notes,
            Status = MembershipStatus.Active,
            Source = MembershipSource.Admin
        };
        return Map(await repository.CreateAsync(m));
    }

    public async Task<SubscriptionResponse?> GetByIdAsync(ulong id)
    {
        var m = await repository.GetByIdAsync(id);
        return m is null ? null : Map(m);
    }

    public async Task<SubscriptionResponse?> RenewAsync(ulong id, RenewSubscriptionRequest request)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        m.Status = MembershipStatus.Active;
        m.EndsAt = request.NewEndsAt;
        await repository.UpdateAsync(m);
        return Map(m);
    }

    public async Task<SubscriptionResponse?> UpgradeAsync(ulong id, UpgradeSubscriptionRequest request)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        m.PlanId = request.NewPlanId;
        await repository.UpdateAsync(m);
        return Map(m);
    }

    public async Task<SubscriptionResponse?> DowngradeAsync(ulong id, DowngradeSubscriptionRequest request)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        m.PlanId = request.NewPlanId;
        await repository.UpdateAsync(m);
        return Map(m);
    }

    public async Task<SubscriptionResponse?> FreezeAsync(ulong id, FreezeSubscriptionRequest request)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        m.Status = MembershipStatus.Paused;
        m.PausedAt = DateTime.UtcNow;
        await repository.UpdateAsync(m);
        return Map(m);
    }

    public async Task<SubscriptionResponse?> UnfreezeAsync(ulong id)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        m.Status = MembershipStatus.Active;
        m.PausedAt = null;
        await repository.UpdateAsync(m);
        return Map(m);
    }

    public async Task<bool> CancelAsync(ulong id)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return false;
        m.Status = MembershipStatus.Cancelled;
        m.CancelledAt = DateTime.UtcNow;
        await repository.UpdateAsync(m);
        return true;
    }

    public async Task<SubscriptionUsageResponse?> GetUsageAsync(ulong id)
    {
        var m = await repository.GetByIdAsync(id);
        if (m is null) return null;
        var days = m.EndsAt.HasValue
            ? (int)(m.EndsAt.Value.ToDateTime(TimeOnly.MinValue) - m.StartsAt.ToDateTime(TimeOnly.MinValue)).TotalDays
            : (int)(DateTime.UtcNow - m.StartsAt.ToDateTime(TimeOnly.MinValue)).TotalDays;
        return new SubscriptionUsageResponse { SubscriptionId = id, DaysActive = Math.Max(0, days) };
    }

    private static SubscriptionResponse Map(GymMembership m) => new()
    {
        Id = m.Id, TenantId = m.TenantId, UserId = m.UserId, PlanId = m.PlanId,
        Status = m.Status.ToString(), StartsAt = m.StartsAt, EndsAt = m.EndsAt,
        AutoRenew = m.AutoRenew, Notes = m.Notes, CreatedAt = m.CreatedAt
    };
}

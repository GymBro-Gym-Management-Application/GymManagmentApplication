using GymManagmentApplication.Application.MembershipPlan.Requests;

namespace GymManagmentApplication.Infrastructure.Repositories.MembershipPlan;

public class MembershipPlanRepository : IMembershipPlanRepository
{
    private static readonly List<Domain.Entities.Membership.MembershipPlan> _store = [];
    private static ulong _id = 1;

    public Task<(List<Domain.Entities.Membership.MembershipPlan> Items, int Total)> GetAllAsync(MembershipPlanListRequest request)
    {
        var q = _store.Where(p => p.IsActive);
        if (request.TenantId.HasValue) q = q.Where(p => p.TenantId == request.TenantId);
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<Domain.Entities.Membership.MembershipPlan> CreateAsync(Domain.Entities.Membership.MembershipPlan plan)
    {
        plan.Id = _id++;
        plan.CreatedAt = DateTime.UtcNow;
        plan.UpdatedAt = DateTime.UtcNow;
        _store.Add(plan);
        return Task.FromResult(plan);
    }

    public Task<Domain.Entities.Membership.MembershipPlan?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(p => p.Id == id && p.IsActive));

    public Task<Domain.Entities.Membership.MembershipPlan?> UpdateAsync(Domain.Entities.Membership.MembershipPlan plan)
    {
        plan.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult<Domain.Entities.Membership.MembershipPlan?>(plan);
    }

    public Task<bool> SoftDeleteAsync(ulong id)
    {
        var p = _store.FirstOrDefault(x => x.Id == id && x.IsActive);
        if (p is null) return Task.FromResult(false);
        p.IsActive = false;
        return Task.FromResult(true);
    }
}

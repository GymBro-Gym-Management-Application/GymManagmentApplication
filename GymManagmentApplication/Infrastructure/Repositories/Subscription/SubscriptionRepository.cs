using GymManagmentApplication.Application.Subscription.Requests;
using GymManagmentApplication.Domain.Entities.Membership;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.Subscription;

public class SubscriptionRepository : ISubscriptionRepository
{
    private static readonly List<GymMembership> _store = [];
    private static ulong _id = 1;

    public Task<(List<GymMembership> Items, int Total)> GetAllAsync(SubscriptionListRequest request)
    {
        var q = _store.AsEnumerable();
        if (request.TenantId.HasValue) q = q.Where(m => m.TenantId == request.TenantId);
        if (!string.IsNullOrWhiteSpace(request.Status) && Enum.TryParse<MembershipStatus>(request.Status, true, out var s))
            q = q.Where(m => m.Status == s);
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<GymMembership> CreateAsync(GymMembership membership)
    {
        membership.Id = _id++;
        membership.CreatedAt = DateTime.UtcNow;
        membership.UpdatedAt = DateTime.UtcNow;
        _store.Add(membership);
        return Task.FromResult(membership);
    }

    public Task<GymMembership?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(m => m.Id == id));

    public Task<GymMembership?> UpdateAsync(GymMembership membership)
    {
        membership.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult<GymMembership?>(membership);
    }
}

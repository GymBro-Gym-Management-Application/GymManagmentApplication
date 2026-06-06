using GymManagmentApplication.Domain.Entities.Membership;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.Corporate;

public class CorporateRepository : ICorporateRepository
{
    private static readonly List<CorporateAccount> _accounts = [];
    private static readonly List<GymMembership> _memberships = [];
    private static ulong _nextId = 1;
    private static ulong _memId = 1;

    public Task<(List<CorporateAccount> Items, int Total)> GetAllAsync(int pageNumber, int pageSize)
    {
        var total = _accounts.Count;
        var items = _accounts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<CorporateAccount> CreateAsync(CorporateAccount account)
    {
        account.Id = _nextId++;
        account.CreatedAt = DateTime.UtcNow;
        _accounts.Add(account);
        return Task.FromResult(account);
    }

    public Task<CorporateAccount?> GetByIdAsync(ulong id) =>
        Task.FromResult(_accounts.FirstOrDefault(a => a.Id == id));

    public Task<CorporateAccount> UpdateAsync(CorporateAccount account) => Task.FromResult(account);

    public Task<List<GymMembership>> GetMembershipsAsync(ulong corporateId) =>
        Task.FromResult(_memberships.Where(m => m.CorporateId == corporateId && m.Status != MembershipStatus.Cancelled).ToList());

    public Task<GymMembership> AddMembershipAsync(GymMembership membership)
    {
        membership.Id = _memId++;
        membership.CreatedAt = DateTime.UtcNow;
        membership.UpdatedAt = DateTime.UtcNow;
        _memberships.Add(membership);
        return Task.FromResult(membership);
    }

    public Task<bool> RemoveMembershipAsync(ulong corporateId, ulong userId)
    {
        var m = _memberships.FirstOrDefault(x => x.CorporateId == corporateId && x.UserId == userId && x.Status != MembershipStatus.Cancelled);
        if (m is null) return Task.FromResult(false);
        m.Status = MembershipStatus.Cancelled;
        m.CancelledAt = DateTime.UtcNow;
        return Task.FromResult(true);
    }
}

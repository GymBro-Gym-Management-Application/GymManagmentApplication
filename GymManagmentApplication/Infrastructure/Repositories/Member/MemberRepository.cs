using GymManagmentApplication.Application.Member.Requests;
using GymManagmentApplication.Domain.Entities.Identity;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.Member;

public class MemberRepository : IMemberRepository
{
    private static readonly List<User> _store = [];
    private static ulong _nextId = 1;

    public Task<(List<User> Items, int Total)> GetAllAsync(MemberSearchRequest request)
    {
        var query = _store.Where(u => u.DeletedAt == null);
        if (!string.IsNullOrWhiteSpace(request.Status) && Enum.TryParse<UserStatus>(request.Status, true, out var status))
            query = query.Where(u => u.Status == status);
        if (!string.IsNullOrWhiteSpace(request.Query))
            query = query.Where(u => u.FirstName.Contains(request.Query, StringComparison.OrdinalIgnoreCase)
                                  || u.LastName.Contains(request.Query, StringComparison.OrdinalIgnoreCase)
                                  || u.Email.Contains(request.Query, StringComparison.OrdinalIgnoreCase));
        var total = query.Count();
        var items = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<User> CreateAsync(User user)
    {
        user.Id = _nextId++;
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;
        _store.Add(user);
        return Task.FromResult(user);
    }

    public Task<User?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(u => u.Id == id && u.DeletedAt == null));

    public Task<User?> UpdateAsync(User user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult<User?>(user);
    }

    public Task<bool> SoftDeleteAsync(ulong id)
    {
        var user = _store.FirstOrDefault(u => u.Id == id && u.DeletedAt == null);
        if (user is null) return Task.FromResult(false);
        user.DeletedAt = DateTime.UtcNow;
        return Task.FromResult(true);
    }
}

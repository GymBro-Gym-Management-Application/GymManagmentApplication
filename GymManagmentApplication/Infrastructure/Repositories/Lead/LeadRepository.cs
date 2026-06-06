using GymManagmentApplication.Application.Lead.Requests;
using GymManagmentApplication.Domain.Entities.CRM;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.Lead;

public class LeadRepository : ILeadRepository
{
    private static readonly List<Domain.Entities.CRM.Lead> _store = [];
    private static readonly List<LeadActivity> _activities = [];
    private static ulong _nextId = 1;
    private static ulong _actId = 1;

    public Task<(List<Domain.Entities.CRM.Lead> Items, int Total)> GetAllAsync(LeadListRequest request)
    {
        var query = _store.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(request.Status) && Enum.TryParse<LeadStatus>(request.Status, true, out var status))
            query = query.Where(l => l.Status == status);
        var total = query.Count();
        var items = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<Domain.Entities.CRM.Lead> CreateAsync(Domain.Entities.CRM.Lead lead)
    {
        lead.Id = _nextId++;
        lead.CreatedAt = DateTime.UtcNow;
        lead.UpdatedAt = DateTime.UtcNow;
        _store.Add(lead);
        return Task.FromResult(lead);
    }

    public Task<Domain.Entities.CRM.Lead?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(l => l.Id == id));

    public Task<Domain.Entities.CRM.Lead?> UpdateAsync(Domain.Entities.CRM.Lead lead)
    {
        lead.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult<Domain.Entities.CRM.Lead?>(lead);
    }

    public Task<LeadActivity> AddActivityAsync(LeadActivity activity)
    {
        activity.Id = _actId++;
        activity.CreatedAt = DateTime.UtcNow;
        _activities.Add(activity);
        return Task.FromResult(activity);
    }

    public Task<List<Domain.Entities.CRM.Lead>> GetByTenantAsync(ulong tenantId) =>
        Task.FromResult(_store.Where(l => l.TenantId == tenantId).ToList());
}

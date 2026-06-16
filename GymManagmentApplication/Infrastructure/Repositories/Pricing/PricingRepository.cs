using GymManagmentApplication.Application.Pricing.Requests;
using GymManagmentApplication.Domain.Entities.Platform;

namespace GymManagmentApplication.Infrastructure.Repositories.Pricing;

public interface IPricingRepository
{
    Task<(List<PricingRule> Items, int Total)> GetRulesAsync(PricingRuleListRequest request);
    Task<PricingRule> CreateRuleAsync(PricingRule rule);
    Task<PricingRule?> GetRuleByIdAsync(ulong id);
    Task<PricingRule?> UpdateRuleAsync(PricingRule rule);
    Task<bool> DeleteRuleAsync(ulong id);
}

public class PricingRepository : IPricingRepository
{
    private static readonly List<PricingRule> _rules = [];
    private static ulong _id = 1;

    public Task<(List<PricingRule> Items, int Total)> GetRulesAsync(PricingRuleListRequest request)
    {
        var q = _rules.Where(r => r.IsActive);
        if (request.TenantId.HasValue) q = q.Where(r => r.TenantId == request.TenantId);
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<PricingRule> CreateRuleAsync(PricingRule rule)
    {
        rule.Id = _id++;
        rule.CreatedAt = DateTime.UtcNow;
        _rules.Add(rule);
        return Task.FromResult(rule);
    }

    public Task<PricingRule?> GetRuleByIdAsync(ulong id) =>
        Task.FromResult(_rules.FirstOrDefault(r => r.Id == id && r.IsActive));

    public Task<PricingRule?> UpdateRuleAsync(PricingRule rule) =>
        Task.FromResult<PricingRule?>(rule);

    public Task<bool> DeleteRuleAsync(ulong id)
    {
        var r = _rules.FirstOrDefault(x => x.Id == id);
        if (r is null) return Task.FromResult(false);
        r.IsActive = false;
        return Task.FromResult(true);
    }
}

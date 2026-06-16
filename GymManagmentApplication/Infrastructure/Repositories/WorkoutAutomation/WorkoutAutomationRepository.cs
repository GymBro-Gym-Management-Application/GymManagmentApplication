using GymManagmentApplication.Application.WorkoutAutomation.Requests;
using GymManagmentApplication.Domain.Entities.Training;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories.WorkoutAutomation;

public class WorkoutAutomationRepository : IWorkoutAutomationRepository
{
    private static readonly List<WorkoutAutomationRule> _rules = [];
    private static readonly List<WorkoutAutomationLog> _logs = [];
    private static ulong _ruleId = 1, _logId = 1;

    public Task<List<WorkoutAutomationRule>> GetRulesAsync(ulong tenantId) =>
        Task.FromResult(_rules.Where(r => r.TenantId == tenantId).ToList());

    public Task<WorkoutAutomationRule> CreateRuleAsync(WorkoutAutomationRule rule)
    {
        rule.Id = _ruleId++;
        rule.CreatedAt = DateTime.UtcNow;
        _rules.Add(rule);
        return Task.FromResult(rule);
    }

    public Task<WorkoutAutomationRule?> GetRuleByIdAsync(ulong id) =>
        Task.FromResult(_rules.FirstOrDefault(r => r.Id == id));

    public Task<WorkoutAutomationRule?> UpdateRuleAsync(WorkoutAutomationRule rule)
    {
        var idx = _rules.FindIndex(r => r.Id == rule.Id);
        if (idx < 0) return Task.FromResult<WorkoutAutomationRule?>(null);
        _rules[idx] = rule;
        return Task.FromResult<WorkoutAutomationRule?>(rule);
    }

    public Task<bool> DeleteRuleAsync(ulong id)
    {
        var r = _rules.FirstOrDefault(x => x.Id == id);
        if (r is null) return Task.FromResult(false);
        r.IsActive = false;
        return Task.FromResult(true);
    }

    public Task<WorkoutAutomationLog> CreateLogAsync(WorkoutAutomationLog log)
    {
        log.Id = _logId++;
        _logs.Add(log);
        return Task.FromResult(log);
    }

    public Task<(List<WorkoutAutomationLog> Items, int Total)> GetLogsAsync(AutomationLogListRequest request)
    {
        var q = _logs.AsQueryable();
        if (request.RuleId.HasValue) q = q.Where(l => l.RuleId == request.RuleId);
        var total = q.Count();
        var items = q.OrderByDescending(l => l.ExecutedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }
}

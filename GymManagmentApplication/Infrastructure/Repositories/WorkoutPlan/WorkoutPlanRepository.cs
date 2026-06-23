using GymManagmentApplication.Application.WorkoutPlan.Requests;
using GymManagmentApplication.Domain.Entities.Training;
using Plan = GymManagmentApplication.Domain.Entities.Training.WorkoutPlan;

namespace GymManagmentApplication.Infrastructure.Repositories.WorkoutPlan;

public class WorkoutPlanRepository : IWorkoutPlanRepository
{
    private static readonly List<Plan> _plans = [];
    private static readonly List<WorkoutPlanBranch> _branches = [];
    private static readonly List<WorkoutPlanAssignment> _assignments = [];
    private static ulong _planId = 1, _branchId = 1, _assignId = 1;

    public Task<(List<Plan> Items, int Total)> GetAllAsync(PlanListRequest request)
    {
        var q = _plans.AsQueryable();
        if (request.TenantId.HasValue) q = q.Where(p => p.TenantId == request.TenantId);
        if (request.Goal.HasValue) q = q.Where(p => p.Goal == request.Goal);
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<Plan> CreateAsync(Plan plan)
    {
        plan.Id = _planId++;
        plan.CreatedAt = DateTime.UtcNow;
        _plans.Add(plan);
        return Task.FromResult(plan);
    }

    public Task<Plan?> GetByIdAsync(ulong id) =>
        Task.FromResult(_plans.FirstOrDefault(p => p.Id == id));

    public Task<Plan?> UpdateAsync(Plan plan)
    {
        var idx = _plans.FindIndex(p => p.Id == plan.Id);
        if (idx < 0) return Task.FromResult<Plan?>(null);
        _plans[idx] = plan;
        return Task.FromResult<Plan?>(plan);
    }

    public Task<bool> DeleteAsync(ulong id)
    {
        var p = _plans.FirstOrDefault(x => x.Id == id);
        if (p is null) return Task.FromResult(false);
        p.IsActive = false;
        return Task.FromResult(true);
    }

    public Task<WorkoutPlanBranch> CreateBranchAsync(WorkoutPlanBranch branch)
    {
        branch.Id = _branchId++;
        _branches.Add(branch);
        return Task.FromResult(branch);
    }

    public Task<WorkoutPlanAssignment> CreateAssignmentAsync(WorkoutPlanAssignment assignment)
    {
        assignment.Id = _assignId++;
        _assignments.Add(assignment);
        return Task.FromResult(assignment);
    }

    public Task<List<WorkoutPlanAssignment>> GetAssignmentsAsync(ulong planId) =>
        Task.FromResult(_assignments.Where(a => a.PlanId == planId).ToList());
}

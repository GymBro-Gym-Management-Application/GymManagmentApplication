using GymManagmentApplication.Application.Workout.Requests;
using GymManagmentApplication.Domain.Entities.Training;

namespace GymManagmentApplication.Infrastructure.Repositories.Workout;

public class WorkoutRepository : IWorkoutRepository
{
    private static readonly List<WorkoutTemplate> _store = [];
    private static readonly List<WorkoutAssignment> _assignments = [];
    private static readonly List<WorkoutLog> _logs = [];
    private static ulong _id = 1, _assignId = 1, _logId = 1;

    public Task<(List<WorkoutTemplate> Items, int Total)> GetAllAsync(WorkoutListRequest request)
    {
        var q = _store.AsQueryable();
        if (request.Difficulty.HasValue) q = q.Where(w => w.Difficulty == request.Difficulty.Value);
        if (!string.IsNullOrEmpty(request.Category)) q = q.Where(w => w.Category == request.Category);
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<WorkoutTemplate> CreateAsync(WorkoutTemplate template)
    {
        template.Id = _id++;
        template.CreatedAt = DateTime.UtcNow;
        _store.Add(template);
        return Task.FromResult(template);
    }

    public Task<WorkoutTemplate?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(w => w.Id == id));

    public Task<WorkoutTemplate?> UpdateAsync(WorkoutTemplate template)
    {
        var idx = _store.FindIndex(w => w.Id == template.Id);
        if (idx < 0) return Task.FromResult<WorkoutTemplate?>(null);
        _store[idx] = template;
        return Task.FromResult<WorkoutTemplate?>(template);
    }

    public Task<bool> DeleteAsync(ulong id)
    {
        var w = _store.FirstOrDefault(x => x.Id == id);
        if (w is null) return Task.FromResult(false);
        _store.Remove(w);
        return Task.FromResult(true);
    }

    public Task<WorkoutAssignment> CreateAssignmentAsync(WorkoutAssignment assignment)
    {
        assignment.Id = _assignId++;
        _assignments.Add(assignment);
        return Task.FromResult(assignment);
    }

    public Task<WorkoutLog> CreateLogAsync(WorkoutLog log)
    {
        log.Id = _logId++;
        _logs.Add(log);
        return Task.FromResult(log);
    }

    public Task<List<WorkoutLog>> GetLogsByWorkoutAndClientAsync(ulong workoutId, ulong clientId) =>
        Task.FromResult(_logs.Where(l => l.TemplateId == workoutId && l.ClientId == clientId).ToList());
}

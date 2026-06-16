using GymManagmentApplication.Application.Exercise.Requests;
using GymManagmentApplication.Domain.Entities.Training;

namespace GymManagmentApplication.Infrastructure.Repositories.Exercise;

public class ExerciseRepository : IExerciseRepository
{
    private static readonly List<Domain.Entities.Training.Exercise> _store = [];
    private static readonly List<MuscleGroup> _muscles =
    [
        new() { Id = 1, Name = "Chest" }, new() { Id = 2, Name = "Back" },
        new() { Id = 3, Name = "Shoulders" }, new() { Id = 4, Name = "Biceps" },
        new() { Id = 5, Name = "Triceps" }, new() { Id = 6, Name = "Legs" },
        new() { Id = 7, Name = "Core" }, new() { Id = 8, Name = "Glutes" },
        new() { Id = 9, Name = "Calves" }, new() { Id = 10, Name = "Forearms" }
    ];
    private static readonly List<Domain.Entities.Training.Equipment> _equipment =
    [
        new() { Id = 1, Name = "Barbell" }, new() { Id = 2, Name = "Dumbbell" },
        new() { Id = 3, Name = "Kettlebell" }, new() { Id = 4, Name = "Cable Machine" },
        new() { Id = 5, Name = "Resistance Band" }, new() { Id = 6, Name = "Bodyweight" }
    ];
    private static ulong _id = 1;

    public Task<(List<Domain.Entities.Training.Exercise> Items, int Total)> GetAllAsync(ExerciseListRequest request)
    {
        var q = _store.AsQueryable();
        if (request.MuscleId.HasValue)
            q = q.Where(e => e.ExerciseMuscles.Any(m => m.MuscleId == request.MuscleId));
        if (request.EquipmentId.HasValue)
            q = q.Where(e => e.ExerciseEquipments.Any(eq => eq.EquipmentId == request.EquipmentId));
        var total = q.Count();
        var items = q.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
        return Task.FromResult((items, total));
    }

    public Task<Domain.Entities.Training.Exercise> CreateAsync(Domain.Entities.Training.Exercise exercise)
    {
        exercise.Id = _id++;
        exercise.CreatedAt = DateTime.UtcNow;
        _store.Add(exercise);
        return Task.FromResult(exercise);
    }

    public Task<Domain.Entities.Training.Exercise?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(e => e.Id == id));

    public Task<Domain.Entities.Training.Exercise?> UpdateAsync(Domain.Entities.Training.Exercise exercise)
    {
        var idx = _store.FindIndex(e => e.Id == exercise.Id);
        if (idx < 0) return Task.FromResult<Domain.Entities.Training.Exercise?>(null);
        _store[idx] = exercise;
        return Task.FromResult<Domain.Entities.Training.Exercise?>(exercise);
    }

    public Task<bool> DeleteAsync(ulong id)
    {
        var e = _store.FirstOrDefault(x => x.Id == id);
        if (e is null) return Task.FromResult(false);
        e.IsActive = false;
        return Task.FromResult(true);
    }

    public Task<List<Domain.Entities.Training.Exercise>> GetAlternativesAsync(ulong id)
    {
        var ex = _store.FirstOrDefault(e => e.Id == id);
        if (ex is null) return Task.FromResult(new List<Domain.Entities.Training.Exercise>());
        var alts = _store.Where(e => e.Id != id && e.Category == ex.Category && e.IsActive).Take(5).ToList();
        return Task.FromResult(alts);
    }

    public Task<List<string>> GetAllTagsAsync()
    {
        var tags = _store
            .Where(e => e.Tags != null)
            .SelectMany(e => e.Tags!.RootElement.EnumerateArray().Select(t => t.GetString() ?? ""))
            .Distinct().OrderBy(t => t).ToList();
        return Task.FromResult(tags);
    }

    public Task<List<MuscleGroup>> GetAllMusclesAsync() => Task.FromResult(_muscles);
    public Task<List<Domain.Entities.Training.Equipment>> GetAllEquipmentAsync() => Task.FromResult(_equipment);
}

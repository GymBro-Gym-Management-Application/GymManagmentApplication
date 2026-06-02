using GymManagmentApplication.Domain.Entities.Training;

namespace GymManagmentApplication.Infrastructure.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private static readonly List<TrainerProfile> _store = [];
    private static ulong _nextId = 1;

    public Task<TrainerProfile?> GetByIdAsync(ulong id) =>
        Task.FromResult(_store.FirstOrDefault(t => t.Id == id));

    public Task<TrainerProfile> CreateAsync(TrainerProfile trainer)
    {
        trainer.Id = _nextId++;
        trainer.CreatedAt = DateTime.UtcNow;
        trainer.UpdatedAt = DateTime.UtcNow;
        _store.Add(trainer);
        return Task.FromResult(trainer);
    }
}

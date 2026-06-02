using GymManagmentApplication.Domain.Entities.Training;

namespace GymManagmentApplication.Infrastructure.Repositories;

public interface ITrainerRepository
{
    Task<TrainerProfile?> GetByIdAsync(ulong id);
    Task<TrainerProfile> CreateAsync(TrainerProfile trainer);
}

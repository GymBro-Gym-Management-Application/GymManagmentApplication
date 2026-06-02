using GymManagmentApplication.Application.Trainer.Requests;
using GymManagmentApplication.Application.Trainer.Responses;

namespace GymManagmentApplication.Application.Trainer.Interfaces;

public interface ITrainerService
{
    Task<TrainerResponse> CreateAsync(CreateTrainerRequest request);
    Task<TrainerResponse?> GetByIdAsync(ulong id);
}

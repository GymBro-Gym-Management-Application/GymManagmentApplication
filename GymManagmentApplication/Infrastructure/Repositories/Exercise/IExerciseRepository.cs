using GymManagmentApplication.Application.Exercise.Requests;
using GymManagmentApplication.Domain.Entities.Training;

namespace GymManagmentApplication.Infrastructure.Repositories.Exercise;

public interface IExerciseRepository
{
    Task<(List<Domain.Entities.Training.Exercise> Items, int Total)> GetAllAsync(ExerciseListRequest request);
    Task<Domain.Entities.Training.Exercise> CreateAsync(Domain.Entities.Training.Exercise exercise);
    Task<Domain.Entities.Training.Exercise?> GetByIdAsync(ulong id);
    Task<Domain.Entities.Training.Exercise?> UpdateAsync(Domain.Entities.Training.Exercise exercise);
    Task<bool> DeleteAsync(ulong id);
    Task<List<Domain.Entities.Training.Exercise>> GetAlternativesAsync(ulong id);
    Task<List<string>> GetAllTagsAsync();
    Task<List<MuscleGroup>> GetAllMusclesAsync();
    Task<List<Domain.Entities.Training.Equipment>> GetAllEquipmentAsync();
}

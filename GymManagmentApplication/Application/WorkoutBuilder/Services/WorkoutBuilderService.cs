using GymManagmentApplication.Application.WorkoutBuilder.Interfaces;
using GymManagmentApplication.Application.WorkoutBuilder.Requests;
using GymManagmentApplication.Application.WorkoutBuilder.Responses;
using GymManagmentApplication.Domain.Entities.Training;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Application.WorkoutBuilder.Services;

public class WorkoutBuilderService : IWorkoutBuilderService
{
    private static readonly List<WorkoutSection> _sections = [];
    private static readonly Dictionary<string, object> _configs = [];
    private static ulong _sectionId = 1;

    public Task<SectionResponse> AddCircuitAsync(ulong workoutId, AddCircuitRequest request)
    {
        var section = CreateSection(workoutId, request.Name ?? "Circuit", SectionType.Circuit, request.Rounds, request.RestSeconds);
        return Task.FromResult(MapSection(section));
    }

    public Task<SectionResponse?> UpdateCircuitAsync(ulong workoutId, ulong circuitId, UpdateCircuitRequest request)
    {
        var section = _sections.FirstOrDefault(s => s.Id == circuitId && s.TemplateId == workoutId);
        if (section is null) return Task.FromResult<SectionResponse?>(null);
        if (request.Name is not null) section.Name = request.Name;
        if (request.Rounds.HasValue) section.Rounds = request.Rounds.Value;
        if (request.RestSeconds.HasValue) section.RestSeconds = request.RestSeconds;
        return Task.FromResult<SectionResponse?>(MapSection(section));
    }

    public Task<SectionResponse> AddSupersetAsync(ulong workoutId, AddSupersetRequest request)
    {
        var section = CreateSection(workoutId, "Superset", SectionType.Superset, request.Sets, request.RestSeconds);
        return Task.FromResult(MapSection(section));
    }

    public Task<SectionResponse> AddDropsetAsync(ulong workoutId, AddDropsetRequest request)
    {
        var section = CreateSection(workoutId, "Dropset", SectionType.Dropset, 1, null);
        return Task.FromResult(MapSection(section));
    }

    public Task<SectionResponse> AddPyramidAsync(ulong workoutId, AddPyramidRequest request)
    {
        var section = CreateSection(workoutId, $"Pyramid ({request.Direction})", SectionType.Pyramid, 1, null);
        return Task.FromResult(MapSection(section));
    }

    public Task<BuilderConfigResponse> SetTempoAsync(ulong workoutId, SetTempoRequest request)
    {
        _configs[workoutId + ":tempo"] = request;
        return Task.FromResult(BuildConfig(workoutId, "tempo", request));
    }

    public Task<BuilderConfigResponse> SetRestIntervalsAsync(ulong workoutId, SetRestIntervalsRequest request)
    {
        _configs[workoutId + ":rest"] = request;
        return Task.FromResult(BuildConfig(workoutId, "rest-intervals", request));
    }

    public Task<BuilderConfigResponse> ConfigureTimerAsync(ulong workoutId, ConfigureTimerRequest request)
    {
        _configs[workoutId + ":timer"] = request;
        return Task.FromResult(BuildConfig(workoutId, "timer", request));
    }

    public Task<BuilderConfigResponse> SetDifficultyAsync(ulong workoutId, SetDifficultyRequest request)
    {
        _configs[workoutId + ":difficulty"] = request;
        return Task.FromResult(BuildConfig(workoutId, "difficulty", request));
    }

    private WorkoutSection CreateSection(ulong workoutId, string name, SectionType type, byte rounds, ushort? restSeconds)
    {
        var section = new WorkoutSection
        {
            Id = _sectionId++,
            TemplateId = workoutId,
            Name = name,
            Type = type,
            Rounds = rounds,
            RestSeconds = restSeconds,
            SortOrder = (byte)_sections.Count(s => s.TemplateId == workoutId)
        };
        _sections.Add(section);
        return section;
    }

    private static SectionResponse MapSection(WorkoutSection s) => new()
    {
        Id = s.Id,
        WorkoutId = s.TemplateId,
        Name = s.Name,
        Type = s.Type.ToString(),
        SortOrder = s.SortOrder,
        Rounds = s.Rounds,
        RestSeconds = s.RestSeconds
    };

    private static BuilderConfigResponse BuildConfig(ulong workoutId, string type, object config) => new()
    {
        WorkoutId = workoutId,
        ConfigType = type,
        Config = config,
        UpdatedAt = DateTime.UtcNow
    };
}

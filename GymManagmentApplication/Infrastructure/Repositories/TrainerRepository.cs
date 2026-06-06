using GymManagmentApplication.Domain.Entities.Training;
using GymManagmentApplication.Domain.Enums;

namespace GymManagmentApplication.Infrastructure.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private static readonly List<TrainerProfile> _store = [];
    private static readonly List<TrainerClientAssignment> _assignments = [];
    private static readonly List<TrainerAvailabilitySlot> _slots = [];
    private static ulong _nextId = 1;
    private static ulong _assignId = 1;
    private static ulong _slotId = 1;

    public Task<(List<TrainerProfile> Items, int Total)> GetAllAsync(int pageNumber, int pageSize)
    {
        var total = _store.Count;
        var items = _store.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return Task.FromResult((items, total));
    }

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

    public Task<TrainerProfile> UpdateAsync(TrainerProfile trainer)
    {
        trainer.UpdatedAt = DateTime.UtcNow;
        return Task.FromResult(trainer);
    }

    public Task<List<TrainerClientAssignment>> GetClientAssignmentsAsync(ulong trainerId) =>
        Task.FromResult(_assignments.Where(a => a.TrainerId == trainerId && a.Status == TrainerAssignmentStatus.Active).ToList());

    public Task<TrainerClientAssignment> AddClientAssignmentAsync(TrainerClientAssignment assignment)
    {
        assignment.Id = _assignId++;
        assignment.AssignedAt = DateTime.UtcNow;
        _assignments.Add(assignment);
        return Task.FromResult(assignment);
    }

    public Task<bool> RemoveClientAssignmentAsync(ulong trainerId, ulong clientId)
    {
        var a = _assignments.FirstOrDefault(x => x.TrainerId == trainerId && x.ClientId == clientId && x.Status == TrainerAssignmentStatus.Active);
        if (a is null) return Task.FromResult(false);
        a.Status = TrainerAssignmentStatus.Inactive;
        a.EndedAt = DateTime.UtcNow;
        return Task.FromResult(true);
    }

    public Task<List<TrainerAvailabilitySlot>> GetSlotsAsync(ulong trainerId) =>
        Task.FromResult(_slots.Where(s => s.TrainerId == trainerId && s.IsActive).ToList());

    public Task SetSlotsAsync(ulong trainerId, List<TrainerAvailabilitySlot> slots)
    {
        _slots.RemoveAll(s => s.TrainerId == trainerId);
        foreach (var s in slots) { s.Id = _slotId++; s.TrainerId = trainerId; }
        _slots.AddRange(slots);
        return Task.CompletedTask;
    }

    public Task<List<TrainerProfile>> GetAvailableTrainersAsync(ulong tenantId) =>
        Task.FromResult(_store.Where(t => t.TenantId == tenantId && t.IsAvailable).ToList());
}

using System.Text.Json;

namespace GymManagmentApplication.Domain.Entities.Training;

public class TrainerProfile : BaseEntity
{
    public ulong UserId { get; set; }
    public ulong TenantId { get; set; }
    public JsonDocument? Specializations { get; set; }
    public JsonDocument? Certifications { get; set; }
    public string? Bio { get; set; }
    public byte? ExperienceYears { get; set; }
    public ushort? MaxClients { get; set; }
    public decimal? HourlyRate { get; set; }
    public decimal? Rating { get; set; }
    public uint TotalSessions { get; set; }
    public JsonDocument? Availability { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Identity.User User { get; set; } = default!;
    public Core.Tenant Tenant { get; set; } = default!;
    public ICollection<TrainerClientAssignment> ClientAssignments { get; set; } = [];
    public ICollection<TrainerAvailabilitySlot> AvailabilitySlots { get; set; } = [];
    public ICollection<TrainerTimeOff> TimeOffs { get; set; } = [];
}

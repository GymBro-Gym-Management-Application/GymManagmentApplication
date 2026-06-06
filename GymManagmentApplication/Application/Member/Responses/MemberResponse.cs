namespace GymManagmentApplication.Application.Member.Responses;

public class MemberResponse
{
    public ulong Id { get; set; }
    public ulong TenantId { get; set; }
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Gender { get; set; }
    public DateOnly? Dob { get; set; }
    public string? AvatarUrl { get; set; }
    public string Status { get; set; } = default!;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
}

namespace GymManagmentApplication.Application.Member.Requests;

public class CreateMemberRequest
{
    public ulong TenantId { get; set; }
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Gender { get; set; }
    public DateOnly? Dob { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Notes { get; set; }
}

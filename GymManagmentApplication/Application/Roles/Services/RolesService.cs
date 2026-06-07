using GymManagmentApplication.Application.Roles.Interfaces;
using GymManagmentApplication.Application.Roles.Requests;
using GymManagmentApplication.Application.Roles.Responses;

namespace GymManagmentApplication.Application.Roles.Services;

public class RolesService : IRolesService
{
    private static readonly List<RoleResponse> _roles =
    [
        new() { Id = "1", Name = "admin",   Description = "Full system access",   Permissions = ["members.read","members.write","trainers.read","trainers.write","roles.manage"], CreatedAt = DateTime.UtcNow },
        new() { Id = "2", Name = "trainer", Description = "Trainer access",        Permissions = ["members.read","trainers.read","trainers.write"], CreatedAt = DateTime.UtcNow },
        new() { Id = "3", Name = "client",  Description = "Member/client access",  Permissions = ["members.read"], CreatedAt = DateTime.UtcNow },
    ];

    private static readonly List<PermissionResponse> _permissions =
    [
        new() { Key = "members.read",    Group = "Members",  Description = "View members" },
        new() { Key = "members.write",   Group = "Members",  Description = "Create/update members" },
        new() { Key = "members.delete",  Group = "Members",  Description = "Delete members" },
        new() { Key = "trainers.read",   Group = "Trainers", Description = "View trainers" },
        new() { Key = "trainers.write",  Group = "Trainers", Description = "Create/update trainers" },
        new() { Key = "trainers.delete", Group = "Trainers", Description = "Delete trainers" },
        new() { Key = "leads.read",      Group = "CRM",      Description = "View leads" },
        new() { Key = "leads.write",     Group = "CRM",      Description = "Create/update leads" },
        new() { Key = "roles.manage",    Group = "Roles",    Description = "Manage roles and permissions" },
        new() { Key = "reports.read",    Group = "Reports",  Description = "View reports and analytics" },
    ];

    // userId -> list of roleIds
    private static readonly Dictionary<ulong, List<string>> _userRoles = new()
    {
        [1] = ["1"],
        [2] = ["2"],
        [3] = ["3"],
    };

    private static int _nextId = 4;

    public Task<List<RoleResponse>> GetAllRolesAsync() => Task.FromResult(_roles.ToList());

    public Task<RoleResponse> CreateRoleAsync(CreateRoleRequest request)
    {
        var role = new RoleResponse { Id = (_nextId++).ToString(), Name = request.Name, Description = request.Description, Permissions = [], CreatedAt = DateTime.UtcNow };
        _roles.Add(role);
        return Task.FromResult(role);
    }

    public Task<RoleResponse?> GetRoleByIdAsync(string id) =>
        Task.FromResult(_roles.FirstOrDefault(r => r.Id == id));

    public Task<RoleResponse?> UpdateRoleAsync(string id, UpdateRoleRequest request)
    {
        var role = _roles.FirstOrDefault(r => r.Id == id);
        if (role is null) return Task.FromResult<RoleResponse?>(null);
        if (request.Name is not null) role.Name = request.Name;
        if (request.Description is not null) role.Description = request.Description;
        return Task.FromResult<RoleResponse?>(role);
    }

    public Task<bool> DeleteRoleAsync(string id)
    {
        var role = _roles.FirstOrDefault(r => r.Id == id);
        if (role is null) return Task.FromResult(false);
        _roles.Remove(role);
        return Task.FromResult(true);
    }

    public Task<List<string>> GetRolePermissionsAsync(string id)
    {
        var role = _roles.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(role?.Permissions ?? []);
    }

    public Task<RoleResponse?> UpdateRolePermissionsAsync(string id, UpdateRolePermissionsRequest request)
    {
        var role = _roles.FirstOrDefault(r => r.Id == id);
        if (role is null) return Task.FromResult<RoleResponse?>(null);
        role.Permissions = request.Permissions;
        return Task.FromResult<RoleResponse?>(role);
    }

    public Task<List<PermissionResponse>> GetAllPermissionsAsync() => Task.FromResult(_permissions.ToList());

    public Task<PermissionMatrixResponse> GetPermissionMatrixAsync() =>
        Task.FromResult(new PermissionMatrixResponse
        {
            Matrix = _roles.Select(r => new RolePermissionRow { RoleName = r.Name, Permissions = r.Permissions }).ToList()
        });

    public Task<bool> AssignRoleToUserAsync(ulong userId, AssignRoleRequest request)
    {
        if (!_roles.Any(r => r.Id == request.RoleId)) return Task.FromResult(false);
        if (!_userRoles.TryGetValue(userId, out var roles))
            _userRoles[userId] = roles = [];
        if (!roles.Contains(request.RoleId)) roles.Add(request.RoleId);
        return Task.FromResult(true);
    }

    public Task<bool> RevokeRoleFromUserAsync(ulong userId, string roleId)
    {
        if (!_userRoles.TryGetValue(userId, out var roles)) return Task.FromResult(false);
        return Task.FromResult(roles.Remove(roleId));
    }
}

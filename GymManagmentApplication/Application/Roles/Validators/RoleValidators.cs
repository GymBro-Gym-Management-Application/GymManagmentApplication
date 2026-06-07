using FluentValidation;
using GymManagmentApplication.Application.Roles.Requests;

namespace GymManagmentApplication.Application.Roles.Validators;

public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
{
    public CreateRoleValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
}

public class UpdateRolePermissionsValidator : AbstractValidator<UpdateRolePermissionsRequest>
{
    public UpdateRolePermissionsValidator() => RuleFor(x => x.Permissions).NotNull();
}

public class AssignRoleValidator : AbstractValidator<AssignRoleRequest>
{
    public AssignRoleValidator() => RuleFor(x => x.RoleId).NotEmpty();
}

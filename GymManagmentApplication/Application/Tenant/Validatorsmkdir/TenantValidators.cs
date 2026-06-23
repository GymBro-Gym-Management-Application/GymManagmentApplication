using FluentValidation;
using GymManagmentApplication.Application.Tenant.Requests;

namespace GymManagmentApplication.Application.Tenant.Validators;

public class CreateTenantValidator : AbstractValidator<CreateTenantRequest>
{
    public CreateTenantValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Slug).NotEmpty().MaximumLength(100)
            .Matches("^[a-z0-9-]+$").WithMessage("Slug must be lowercase alphanumeric with hyphens.");
    }
}

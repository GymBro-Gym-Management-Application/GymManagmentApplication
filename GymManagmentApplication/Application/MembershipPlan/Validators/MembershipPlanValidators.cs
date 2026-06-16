using FluentValidation;
using GymManagmentApplication.Application.MembershipPlan.Requests;

namespace GymManagmentApplication.Application.MembershipPlan.Validators;

public class CreateMembershipPlanValidator : AbstractValidator<CreateMembershipPlanRequest>
{
    public CreateMembershipPlanValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BillingCycle).IsInEnum();
    }
}

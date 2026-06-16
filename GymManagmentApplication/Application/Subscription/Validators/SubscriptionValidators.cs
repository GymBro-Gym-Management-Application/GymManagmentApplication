using FluentValidation;
using GymManagmentApplication.Application.Subscription.Requests;

namespace GymManagmentApplication.Application.Subscription.Validators;

public class CreateSubscriptionValidator : AbstractValidator<CreateSubscriptionRequest>
{
    public CreateSubscriptionValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.UserId).GreaterThan(0ul);
        RuleFor(x => x.PlanId).GreaterThan(0ul);
        RuleFor(x => x.StartsAt).NotEmpty();
    }
}

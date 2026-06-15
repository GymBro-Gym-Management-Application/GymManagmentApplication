using FluentValidation;
using GymManagmentApplication.Application.WorkoutAutomation.Requests;

namespace GymManagmentApplication.Application.WorkoutAutomation.Validators;

public class CreateAutomationRuleValidator : AbstractValidator<CreateAutomationRuleRequest>
{
    public CreateAutomationRuleValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.TriggerEvent).NotEmpty();
        RuleFor(x => x.Actions).NotNull();
    }
}

public class TriggerAutomationValidator : AbstractValidator<TriggerAutomationRequest>
{
    public TriggerAutomationValidator()
    {
        RuleFor(x => x.RuleId).GreaterThan(0ul);
    }
}

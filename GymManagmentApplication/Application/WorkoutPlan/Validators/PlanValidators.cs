using FluentValidation;
using GymManagmentApplication.Application.WorkoutPlan.Requests;

namespace GymManagmentApplication.Application.WorkoutPlan.Validators;

public class CreatePlanValidator : AbstractValidator<CreatePlanRequest>
{
    public CreatePlanValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.DurationWeeks).GreaterThan((byte)0);
        RuleFor(x => x.Goal).IsInEnum();
        RuleFor(x => x.Difficulty).IsInEnum();
    }
}

public class UpdatePlanValidator : AbstractValidator<UpdatePlanRequest>
{
    public UpdatePlanValidator()
    {
        RuleFor(x => x.Name).MaximumLength(200).When(x => x.Name is not null);
    }
}

public class AssignPlanValidator : AbstractValidator<AssignPlanRequest>
{
    public AssignPlanValidator()
    {
        RuleFor(x => x.MemberIds).NotEmpty();
        RuleFor(x => x.StartDate).NotEmpty();
    }
}

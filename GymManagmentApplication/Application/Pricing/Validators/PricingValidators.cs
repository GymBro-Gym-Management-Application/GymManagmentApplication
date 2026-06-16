using FluentValidation;
using GymManagmentApplication.Application.Pricing.Requests;

namespace GymManagmentApplication.Application.Pricing.Validators;

public class CreatePricingRuleValidator : AbstractValidator<CreatePricingRuleRequest>
{
    public CreatePricingRuleValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.PriceModifier).GreaterThanOrEqualTo(0);
        RuleFor(x => x.AppliesTo).IsInEnum();
        RuleFor(x => x.RuleType).IsInEnum();
        RuleFor(x => x.ModifierType).IsInEnum();
    }
}

public class CreateDiscountValidator : AbstractValidator<CreateDiscountRequest>
{
    public CreateDiscountValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Value).GreaterThan(0);
        RuleFor(x => x.Type).IsInEnum();
    }
}

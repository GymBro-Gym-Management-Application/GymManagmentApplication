using FluentValidation;
using GymManagmentApplication.Application.Payment.Requests;

namespace GymManagmentApplication.Application.Payment.Validators;

public class ChargePaymentValidator : AbstractValidator<ChargePaymentRequest>
{
    public ChargePaymentValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.InvoiceId).GreaterThan(0ul);
        RuleFor(x => x.Amount).GreaterThan(0);
        RuleFor(x => x.Method).IsInEnum();
    }
}

public class RefundPaymentValidator : AbstractValidator<RefundPaymentRequest>
{
    public RefundPaymentValidator()
    {
        RuleFor(x => x.PaymentId).GreaterThan(0ul);
        RuleFor(x => x.Amount).GreaterThan(0).When(x => x.Amount.HasValue);
    }
}

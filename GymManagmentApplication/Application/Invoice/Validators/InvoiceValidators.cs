using FluentValidation;
using GymManagmentApplication.Application.Invoice.Requests;

namespace GymManagmentApplication.Application.Invoice.Validators;

public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceRequest>
{
    public CreateInvoiceValidator()
    {
        RuleFor(x => x.TenantId).GreaterThan(0ul);
        RuleFor(x => x.UserId).GreaterThan(0ul);
        RuleFor(x => x.Subtotal).GreaterThanOrEqualTo(0);
    }
}

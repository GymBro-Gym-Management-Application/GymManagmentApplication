using FluentValidation;
using GymManagmentApplication.Application.Trainer.Requests;

namespace GymManagmentApplication.Application.Trainer.Validators;

public class CreateTrainerValidator : AbstractValidator<CreateTrainerRequest>
{
    public CreateTrainerValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0ul).WithMessage("UserId is required.");
        RuleFor(x => x.TenantId).GreaterThan(0ul).WithMessage("TenantId is required.");
        RuleFor(x => x.Email).EmailAddress().When(x => x.Email is not null);
        RuleFor(x => x.ExperienceYears).InclusiveBetween((byte)0, (byte)60).When(x => x.ExperienceYears.HasValue);
        RuleFor(x => x.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Today)).When(x => x.DateOfBirth.HasValue);

        When(x => x.Salary is not null, () =>
        {
            RuleFor(x => x.Salary!.BasicSalary).GreaterThanOrEqualTo(0).When(x => x.Salary!.BasicSalary.HasValue);
            RuleFor(x => x.Salary!.HourlyRate).GreaterThan(0).When(x => x.Salary!.HourlyRate.HasValue);
            RuleFor(x => x.Salary!.CommissionValue).InclusiveBetween(0, 100)
                .When(x => x.Salary!.CommissionValue.HasValue && x.Salary.CommissionType == "Percentage");
        });

        When(x => x.BookingSettings is not null, () =>
        {
            RuleFor(x => x.BookingSettings!.MaxClients).GreaterThan((ushort)0).When(x => x.BookingSettings!.MaxClients.HasValue);
            RuleFor(x => x.BookingSettings!.SessionDurationMinutes).GreaterThan((ushort)0).When(x => x.BookingSettings!.SessionDurationMinutes.HasValue);
        });

        RuleForEach(x => x.Certifications).ChildRules(cert =>
        {
            cert.RuleFor(c => c.CertificateName).NotEmpty();
            cert.RuleFor(c => c.IssuedBy).NotEmpty();
        }).When(x => x.Certifications is not null);

        When(x => x.EmergencyContact is not null, () =>
        {
            RuleFor(x => x.EmergencyContact!.Name).NotEmpty();
            RuleFor(x => x.EmergencyContact!.Phone).NotEmpty();
        });
    }
}

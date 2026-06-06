using FluentValidation;
using GymManagmentApplication.Application.Auth.Requests;

namespace GymManagmentApplication.Application.Auth.Validators;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}

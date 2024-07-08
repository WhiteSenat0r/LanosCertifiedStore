using FluentValidation;

namespace Application.Identity.Commands.Authentication.Register;

internal sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.RegisterDto.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(32);

        RuleFor(x => x.RegisterDto.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(32);

        RuleFor(x => x.RegisterDto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.RegisterDto.Password)
            .NotEmpty()
            .Must(password => password.Any(char.IsDigit)).WithMessage("Password should contain digits!")
            .Must(password => password.Any(char.IsUpper) && password.Any(char.IsLower))
            .WithMessage("Password should contain upper and lower-case characters!");
    }
}
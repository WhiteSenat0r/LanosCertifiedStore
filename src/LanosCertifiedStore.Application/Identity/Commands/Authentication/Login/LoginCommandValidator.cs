using FluentValidation;

namespace Application.Identity.Commands.Authentication.Login;

internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.LoginDto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.LoginDto.Password)
            .NotEmpty();
    }
}
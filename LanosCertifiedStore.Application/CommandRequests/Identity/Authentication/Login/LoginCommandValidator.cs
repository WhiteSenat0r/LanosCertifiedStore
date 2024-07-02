using FluentValidation;

namespace Application.CommandRequests.Identity.Authentication.Login;

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
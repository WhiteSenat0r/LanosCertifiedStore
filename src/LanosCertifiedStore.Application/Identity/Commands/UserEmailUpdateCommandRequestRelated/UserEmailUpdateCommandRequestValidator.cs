using FluentValidation;

namespace LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;

internal sealed class UserEmailUpdateCommandRequestValidator : AbstractValidator<UserEmailUpdateCommandRequest>
{
    public UserEmailUpdateCommandRequestValidator()
    {
        RuleFor(x => x.NewEmail).EmailAddress();
    }
}
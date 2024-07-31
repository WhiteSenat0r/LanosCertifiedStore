using FluentValidation;

namespace LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;

internal sealed class UpdateUserSelfCommandRequestValidator : AbstractValidator<UpdateUserSelfCommandRequest>
{
    public UpdateUserSelfCommandRequestValidator()
    {
        const string phoneNumberRegex = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(phoneNumberRegex);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);
    }
}
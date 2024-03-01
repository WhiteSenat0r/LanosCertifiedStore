using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator(ValidationHelper<VehicleColor> validationHelper)
    {
        RuleFor(x => x.ColorName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);
        
        RuleFor(x => x.HexValue)
            .NotEmpty()
            .MaximumLength(12)
            .MinimumLength(2);

        RuleFor(x => x.ColorName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Color with such name already exists! Color name must be unique");
    }
}
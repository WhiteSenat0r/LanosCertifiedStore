using Application.Helpers;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator(ValidationHelper<VehicleColor> validationHelper)
    {
        RuleFor(x => x.CreateColorDto.ColorName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);
        
        RuleFor(x => x.CreateColorDto.HexValue)
            .NotEmpty()
            .MaximumLength(12)
            .MinimumLength(2);

        RuleFor(x => x.CreateColorDto.ColorName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Color with such name already exists! Color name must be unique");
    }
}
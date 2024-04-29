using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Colors.CreateColor;

internal sealed class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
{
    public CreateColorCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
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
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleColor>(unitOfWork, name))
            .WithMessage("Color with such name already exists!");
    }
}
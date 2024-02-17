using Application.Helpers;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Types.UpdateType;

internal sealed class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator(ValidationHelper<VehicleType> validationHelper)
    {
        RuleFor(x => x.UpdateTypeDto.UpdatedName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.UpdateTypeDto.UpdatedName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Type with such name already exists! Type name must be unique");
    }
}
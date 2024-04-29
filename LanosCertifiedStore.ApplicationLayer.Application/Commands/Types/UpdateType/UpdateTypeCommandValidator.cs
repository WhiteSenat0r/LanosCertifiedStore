using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.UpdateType;

internal sealed class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.UpdatedName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.UpdatedName)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleType>(unitOfWork, name))
            .WithMessage("Type with such name already exists!");
    }
}
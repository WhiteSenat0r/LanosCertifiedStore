using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.CreateType;

internal sealed class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleType>(unitOfWork, name))
            .WithMessage("Type with such name already exists!");
    }
}
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Types.VehicleTransmissionTypeRelated.CreateTransmissionType;

internal sealed class CreateTransmissionTypeCommandValidator : AbstractValidator<CreateTransmissionTypeCommand>
{
    public CreateTransmissionTypeCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2)
            .WithMessage("Name must be greater than 2 characters and less than 64!");

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleTransmissionType>(unitOfWork, name))
            .WithMessage("Transmission type with such name already exists!");
    }
}
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(20)
            .MaximumLength(3000);

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);
        
        VehicleModel? model = null;

        RuleFor(x => x.ModelId)
            .NotEmpty()
            .MustAsync(async (modelId, _) =>
            {
                model = await unitOfWork.RetrieveRepository<VehicleModel>().GetEntityByIdAsync(modelId);

                return model is not null;
            })
            .WithMessage("Such model doesn't exists!");

        RuleFor(x => x.TypeId)
            .NotEmpty()
            .Must(typeId =>
            {
                if (model is not null)
                    return model.AvailableTypes
                        .Select(x => x.Id)
                        .ToList()
                        .Contains(typeId);

                return false;
            })
            .WithMessage("This type is not available for this model!");
    }
}
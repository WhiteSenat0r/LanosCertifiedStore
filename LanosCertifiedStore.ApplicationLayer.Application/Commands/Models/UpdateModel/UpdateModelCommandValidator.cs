using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Models.UpdateModel;

internal sealed class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.UpdateModelDto.UpdatedName)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.UpdateModelDto.UpdatedName)
            .MustAsync(async (name, _) =>
            {
                var vehicleModels = await unitOfWork.RetrieveRepository<VehicleModel>().GetAllEntitiesAsync();
                return vehicleModels.All(x => x.Name != name);
            })
            .WithMessage("Model with such name already exists! Model name must be unique");
    }
}
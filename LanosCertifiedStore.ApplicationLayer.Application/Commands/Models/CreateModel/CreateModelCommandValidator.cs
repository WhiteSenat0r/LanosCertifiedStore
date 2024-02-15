using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Models.CreateModel;

internal sealed class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(64)
            .MinimumLength(2);

        RuleFor(x => x.BrandId)
            .MustAsync(async (brandId, _) =>
                await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(brandId) is not null)
            .WithMessage("Brand with such id doesn't exists!");

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) =>
            {
                var brands = await unitOfWork.RetrieveRepository<VehicleModel>().GetAllEntitiesAsync();
                return brands.All(x => x.Name != name);
            })
            .WithMessage("Model with such name already exists! Model name must be unique");

    }
}
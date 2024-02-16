using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.UpdateBrandDto.UpdatedName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);

        RuleFor(x => x.UpdateBrandDto.UpdatedName)
            .MustAsync(async (updatedName, _) =>
            {
                var brands = await unitOfWork.RetrieveRepository<VehicleBrand>().GetAllEntitiesAsync();
                return brands.All(x => x.Name != updatedName);
            })
            .WithMessage("Brand with such name already exists! Brand name must be unique");

    }
}
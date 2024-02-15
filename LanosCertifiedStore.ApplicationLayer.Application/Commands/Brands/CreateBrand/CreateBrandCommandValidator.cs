using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(64).MinimumLength(2);
        RuleFor(x => x.Name).MustAsync(async (name, _) =>
        {
            var brands = await unitOfWork.RetrieveRepository<VehicleBrand>().GetAllEntitiesAsync();
            return brands.All(x => x.Name != name);
        }).WithMessage("Brand name must be unique!");
    }
}
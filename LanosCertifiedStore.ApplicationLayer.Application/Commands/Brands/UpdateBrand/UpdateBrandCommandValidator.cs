using Application.Helpers;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator(ValidationHelper<VehicleBrand> validationHelper)
    {
        RuleFor(x => x.UpdateBrandDto.UpdatedName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64);

        RuleFor(x => x.UpdateBrandDto.UpdatedName)
            .MustAsync(async (name, _) => await validationHelper.IsNameUniqueAsync(name))
            .WithMessage("Brand with such name already exists! Brand name must be unique");
    }
}
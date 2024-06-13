using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Models.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.UpdatedName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64)
            .WithMessage("Name must be greater than 2 characters and less than 64!");

        RuleFor(x => x.UpdatedName)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleBrand>(unitOfWork, name))
            .WithMessage("Brand with such name already exists!");
    }
}
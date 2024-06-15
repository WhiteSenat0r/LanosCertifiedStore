using Application.Commands.Brands.Shared;
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Constants.VehicleRelated;
using Domain.Models.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.UpdateBrand;

internal sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.UpdatedName)
            .NotEmpty()
            .MinimumLength(VehicleBrandConstants.MinimalNameLength)
            .MaximumLength(VehicleBrandConstants.MaximumNameLength)
            .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);

        RuleFor(x => x.UpdatedName)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleBrand>(unitOfWork, name))
            .WithMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }
}
using Application.Commands.Brands.Shared;
using Application.Contracts.RepositoryRelated.Common;
using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Constants.VehicleRelated;
using Domain.Models.VehicleRelated.Classes;
using FluentValidation;

namespace Application.Commands.Brands.CreateBrand;

internal sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(VehicleBrandConstants.MinimalNameLength)
            .MaximumLength(VehicleBrandConstants.MaximumNameLength)
            .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);

        RuleFor(x => x.Name)
            .MustAsync(async (name, _) => 
                await validationHelper.IsAspectNameUnique<VehicleBrand>(unitOfWork, name))
            .WithMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }
}
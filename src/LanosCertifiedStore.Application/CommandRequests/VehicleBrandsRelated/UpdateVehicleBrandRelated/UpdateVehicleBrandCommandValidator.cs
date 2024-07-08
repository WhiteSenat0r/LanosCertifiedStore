using System.Linq.Expressions;
using Application.CommandRequests.VehicleBrandsRelated.Shared.MessageRelated;
using Application.Contracts.ValidationRelated;
using Domain.Constants.VehicleRelated;
using Domain.Entities.VehicleRelated;
using FluentValidation;

namespace Application.CommandRequests.VehicleBrandsRelated.UpdateVehicleBrandRelated;

internal sealed class UpdateVehicleBrandCommandRequestValidator : AbstractValidator<UpdateVehicleBrandCommandRequest>
{
    public UpdateVehicleBrandCommandRequestValidator(IValidationHelper validationHelper)
    {
        GetNameLengthValidationRule(x => x.UpdatedName);

        GetNameUniquenessValidationRule(x => x.UpdatedName, validationHelper);
    }

    private void GetNameLengthValidationRule(Expression<Func<UpdateVehicleBrandCommandRequest, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(VehicleBrandConstants.MinimalNameLength)
            .MaximumLength(VehicleBrandConstants.MaximumNameLength)
            .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);
    }

    private void GetNameUniquenessValidationRule(
        Expression<Func<UpdateVehicleBrandCommandRequest, string>> expression,
        IValidationHelper validationHelper)
    {
        RuleFor(expression)
            .MustAsync(async (name, _) =>
            {
                Expression<Func<VehicleBrand, bool>> equalityExpression = brand => brand.Name.Equals(name);

                return await validationHelper.CheckAspectValueUniqueness(name, equalityExpression);
            })
            .WithMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }
}
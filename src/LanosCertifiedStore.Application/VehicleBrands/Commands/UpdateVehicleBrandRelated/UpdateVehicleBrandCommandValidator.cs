using System.Linq.Expressions;
using FluentValidation;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;

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
            .MinimumLength(2)
            .MaximumLength(64)
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
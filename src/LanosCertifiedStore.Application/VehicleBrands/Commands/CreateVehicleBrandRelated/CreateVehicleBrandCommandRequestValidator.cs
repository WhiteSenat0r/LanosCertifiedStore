using System.Linq.Expressions;
using FluentValidation;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

internal sealed class CreateVehicleBrandCommandRequestValidator : AbstractValidator<CreateVehicleBrandCommandRequest>
{
    public CreateVehicleBrandCommandRequestValidator(IValidationHelper validationHelper)
    {
        GetNameLengthValidationRule(x => x.Name);
        GetNameUniquenessValidationRule(x => x.Name, validationHelper);
    }
    
    private void GetNameLengthValidationRule(Expression<Func<CreateVehicleBrandCommandRequest, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64)
            .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);
    }
    
    private void GetNameUniquenessValidationRule(
        Expression<Func<CreateVehicleBrandCommandRequest, string>> expression,
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
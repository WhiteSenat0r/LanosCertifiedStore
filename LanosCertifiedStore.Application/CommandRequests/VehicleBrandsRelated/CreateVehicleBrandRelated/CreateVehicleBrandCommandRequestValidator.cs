using System.Linq.Expressions;
using Application.CommandRequests.VehicleBrandsRelated.Shared.MessageRelated;
using Application.Contracts.ValidationRelated;
using Domain.Constants.VehicleRelated;
using Domain.Entities.VehicleRelated;
using FluentValidation;

namespace Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;

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
            .MinimumLength(VehicleBrandConstants.MinimalNameLength)
            .MaximumLength(VehicleBrandConstants.MaximumNameLength)
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
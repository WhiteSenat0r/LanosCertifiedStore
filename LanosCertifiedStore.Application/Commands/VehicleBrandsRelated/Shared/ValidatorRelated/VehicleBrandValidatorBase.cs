using System.Linq.Expressions;
using Application.Commands.VehicleBrandsRelated.Shared.MessageRelated;
using Application.Contracts.RequestRelated;
using Application.Contracts.ValidationRelated;
using Application.Dtos.BrandDtos;
using Domain.Constants.VehicleRelated;
using Domain.Entities.VehicleRelated;
using FluentValidation;

namespace Application.Commands.VehicleBrandsRelated.Shared.ValidatorRelated;

// TODO
internal abstract class VehicleBrandValidatorBase<TCommandRequest>(
    IValidationHelper validationHelper) : AbstractValidator<TCommandRequest>
    where TCommandRequest : ICommandRequest<VehicleBrand, VehicleBrandDto>
{
    private protected void GetNameLengthValidationRule(Expression<Func<TCommandRequest, string>> expression)
    {
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(VehicleBrandConstants.MinimalNameLength)
            .MaximumLength(VehicleBrandConstants.MaximumNameLength)
            .WithMessage(VehicleBrandValidatorMessages.InvalidNameValue);
    }
    
    private protected void GetNameUniquenessValidationRule(Expression<Func<TCommandRequest, string>> expression)
    {
        RuleFor(expression)
            .MustAsync(async (name, _) => 
                await validationHelper.CheckAspectValueUniqueness<VehicleBrand, string>(
                    name,
                    nameof(VehicleBrand.Name)))
            .WithMessage(VehicleBrandValidatorMessages.AlreadyExistingNameValue);
    }
}
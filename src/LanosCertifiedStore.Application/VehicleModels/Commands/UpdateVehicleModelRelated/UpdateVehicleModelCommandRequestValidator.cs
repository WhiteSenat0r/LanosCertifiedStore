using System.Linq.Expressions;
using Application.Shared.ValidationRelated;
using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated.TypeRelated;
using FluentValidation;

namespace Application.VehicleModels.Commands.UpdateVehicleModelRelated;

internal sealed class UpdateVehicleModelCommandRequestValidator : AbstractValidator<UpdateVehicleModelCommandRequest>
{
    public UpdateVehicleModelCommandRequestValidator(IValidationHelper validationHelper)
    {
        GetBodyTypesValidationRules(validationHelper);
        GetTransmissionTypesValidationRules(validationHelper);
        GetDrivetrainTypesValidationRules(validationHelper);
        GetEngineTypesValidationRules(validationHelper);
    }
    
    private void GetBodyTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<UpdateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableBodyTypesIds;

        RuleFor(expression)
            .NotNull()
            .NotEmpty()
            .WithMessage(VehicleModelValidatorMessages.EmptyBodyTypeCollection);

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleBodyType>(validationHelper, ids, context))
            .WithMessage(VehicleModelValidatorMessages.NonExistingBodyType);
    }

    private void GetEngineTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<UpdateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableEngineTypesIds;
        
        RuleFor(expression)
            .NotNull()
            .NotEmpty()
            .WithMessage(VehicleModelValidatorMessages.EmptyEngineTypeCollection);

        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleEngineType>(validationHelper, ids, context))
            .WithMessage(VehicleModelValidatorMessages.NonExistingEngineType);
    }

    private void GetDrivetrainTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<UpdateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableDrivetrainTypesIds;

        RuleFor(expression)
            .NotNull()
            .NotEmpty()
            .WithMessage(VehicleModelValidatorMessages.EmptyDrivetrainTypeCollection);
        
        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleDrivetrainType>(validationHelper, ids, context))
            .WithMessage(VehicleModelValidatorMessages.NonExistingDrivetrainType);
    }

    private void GetTransmissionTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<UpdateVehicleModelCommandRequest, IEnumerable<Guid>>> expression =
            x => x.AvailableTransmissionTypesIds;

        RuleFor(expression)
            .NotNull()
            .NotEmpty()
            .WithMessage(VehicleModelValidatorMessages.EmptyTransmissionTypeCollection);
        
        RuleFor(expression)
            .MustAsync(async (_, ids, context, _) =>
                await ExistByIds<VehicleTransmissionType>(validationHelper, ids, context))
            .WithMessage(VehicleModelValidatorMessages.NonExistingTransmissionType);
    }

    private static async Task<bool> ExistByIds<TEntity>(
        IValidationHelper validationHelper,
        IEnumerable<Guid> ids,
        ValidationContext<UpdateVehicleModelCommandRequest> context)
        where TEntity : class, IIdentifiable<Guid>
    {
        var checkResult = await validationHelper.CheckMainAspectPresence<TEntity>(ids);

        if (!checkResult.IsSuccess)
        {
            context.MessageFormatter.AppendArgument("AspectId", checkResult.Id);
        }

        return checkResult.IsSuccess;
    }
}
using System.Linq.Expressions;
using Application.Shared.ValidationRelated;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.TypeRelated;
using FluentValidation;

namespace Application.VehicleModels.Commands.CreateVehicleModelRelated;

// TODO Fix empty IDs
internal sealed class CreateVehicleModelCommandRequestValidator : AbstractValidator<CreateVehicleModelCommandRequest>
{
    public CreateVehicleModelCommandRequestValidator(IValidationHelper validationHelper)
    {
        GetNameValidationRules(validationHelper);
        GetBrandValidationRules(validationHelper);
        GetTypeValidationRules(validationHelper);
        GetBodyTypesValidationRules(validationHelper);
        GetTransmissionTypesValidationRules(validationHelper);
        GetDrivetrainTypesValidationRules(validationHelper);
        GetEngineTypesValidationRules(validationHelper);
        GetProductionYearValidationRules();
    }
    
    private void GetNameValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, string>> expression = x => x.Name;
        
        RuleFor(expression)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(64)
            .WithMessage(VehicleModelValidatorMessages.InvalidNameValue);
        
        RuleFor(expression)
            .MustAsync(async (name, _) =>
            {
                Expression<Func<VehicleBrand, bool>> equalityExpression = brand => brand.Name.Equals(name);

                return await validationHelper.CheckAspectValueUniqueness(name, equalityExpression);
            })
            .WithMessage(VehicleModelValidatorMessages.AlreadyExistingNameValue);
    }
    
    private void GetBodyTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression = 
            x => x.AvailableBodyTypesIds;

        var possibleNotFoundAspectId = string.Empty;

        RuleFor(expression)
            .MustAsync(async (ids, _) =>
            {
                var checkResult = await validationHelper.CheckMainAspectPresence<VehicleBodyType>(ids);

                if (!checkResult.IsSuccess)
                {
                    possibleNotFoundAspectId = checkResult.Id!.Value.ToString();
                }

                return checkResult.IsSuccess;
            })
            .WithMessage($"Body type with ID {possibleNotFoundAspectId} does not exist!");
    }
    
    private void GetEngineTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression = 
            x => x.AvailableEngineTypesIds;

        var possibleNotFoundAspectId = string.Empty;

        RuleFor(expression)
            .MustAsync(async (ids, _) =>
            {
                var checkResult = await validationHelper.CheckMainAspectPresence<VehicleEngineType>(ids);

                if (!checkResult.IsSuccess)
                {
                    possibleNotFoundAspectId = checkResult.Id!.Value.ToString();
                }

                return checkResult.IsSuccess;
            })
            .WithMessage($"Engine type with ID {possibleNotFoundAspectId} does not exist!");
    }
    
    private void GetDrivetrainTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression = 
            x => x.AvailableDrivetrainTypesIds;

        var possibleNotFoundAspectId = string.Empty;

        RuleFor(expression)
            .MustAsync(async (ids, _) =>
            {
                var checkResult = await validationHelper.CheckMainAspectPresence<VehicleEngineType>(ids);

                if (!checkResult.IsSuccess)
                {
                    possibleNotFoundAspectId = checkResult.Id!.Value.ToString();
                }

                return checkResult.IsSuccess;
            })
            .WithMessage($"Drivetrain type with ID {possibleNotFoundAspectId} does not exist!");
    }
    
    private void GetTransmissionTypesValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, IEnumerable<Guid>>> expression = 
            x => x.AvailableTransmissionTypesIds;

        var possibleNotFoundAspectId = string.Empty;

        RuleFor(expression)
            .MustAsync(async (ids, _) =>
            {
                var checkResult = await validationHelper.CheckMainAspectPresence<VehicleTransmissionType>(ids);

                if (!checkResult.IsSuccess)
                {
                    possibleNotFoundAspectId = checkResult.Id!.Value.ToString();
                }

                return checkResult.IsSuccess;
            })
            .WithMessage($"Transmission type with ID {possibleNotFoundAspectId} does not exist!");
    }
    
    private void GetBrandValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, Guid>> expression = x => x.BrandId;
        
        RuleFor(expression)
            .MustAsync(async (id, _) => await validationHelper.CheckMainAspectPresence<VehicleBrand>(id))
            .WithMessage(VehicleModelValidatorMessages.InvalidBrandIdValue);
    }
    
    private void GetTypeValidationRules(IValidationHelper validationHelper)
    {
        Expression<Func<CreateVehicleModelCommandRequest, Guid>> expression = x => x.TypeId;
        
        RuleFor(expression)
            .MustAsync(async (id, _) => await validationHelper.CheckMainAspectPresence<VehicleType>(id))
            .WithMessage(VehicleModelValidatorMessages.InvalidTypeIdValue);
    }
    
    private void GetProductionYearValidationRules()
    {
        Expression<Func<CreateVehicleModelCommandRequest, int>> minimalProductionYearExpression = 
            x => x.MinimalProductionYear;
        
        Expression<Func<CreateVehicleModelCommandRequest, int>> maximumProductionYearExpression = 
            x => x.MaximumProductionYear ?? default;
        
        RuleFor(minimalProductionYearExpression)
            .GreaterThanOrEqualTo(1900)
            .WithMessage(VehicleModelValidatorMessages.InvalidMinimalProductionYearValue);
        
        RuleFor(minimalProductionYearExpression)
            .LessThanOrEqualTo(maximumProductionYearExpression)
            .When(p => p.MaximumProductionYear.HasValue)
            .WithMessage(VehicleModelValidatorMessages.TooBigMinimalProductionYearValue);

        RuleFor(maximumProductionYearExpression)
            .GreaterThanOrEqualTo(minimalProductionYearExpression)
            .When(p => p.MaximumProductionYear.HasValue)
            .WithMessage(VehicleModelValidatorMessages.TooSmallMaximumProductionYearValue);
    }
}
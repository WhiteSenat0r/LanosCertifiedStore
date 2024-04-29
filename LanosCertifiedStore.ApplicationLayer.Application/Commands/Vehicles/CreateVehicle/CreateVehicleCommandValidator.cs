using Application.Helpers.ValidationRelated.Common.Contracts;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.LocationRelated;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using FluentValidation;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator(IUnitOfWork unitOfWork, IValidationHelper validationHelper)
    {
        RuleFor(x => x.Description)
            .NotEmpty()
            .MinimumLength(20)
            .MaximumLength(3000);

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Displacement)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.ModelId)
            .NotEmpty()
            .MustAsync(async (modelId, _) => 
                await validationHelper.CheckMainAspectPresence<VehicleModel>(unitOfWork, modelId))
            .WithMessage("Such model doesn't exists!");
        
        RuleFor(x => new { x.ModelId, x.BodyTypeId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleModel, VehicleBodyType>(
                    unitOfWork, (ids.ModelId, ids.BodyTypeId), m => m.AvailableBodyTypes.Select(i => i.Id)))
            .OverridePropertyName("ModelIdBodyTypeId")
            .WithMessage("Such body type is not contained by the given model!");
        
        RuleFor(x => new { x.ModelId, x.EngineTypeId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleModel, VehicleEngineType>(
                    unitOfWork, (ids.ModelId, ids.EngineTypeId), m => m.AvailableEngineTypes.Select(i => i.Id)))
            .OverridePropertyName("ModelIdEngineTypeId")
            .WithMessage("Such engine type is not contained by the given model!");
        
        RuleFor(x => new { x.ModelId, x.TransmissionTypeId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleModel, VehicleTransmissionType>(
                    unitOfWork, (ids.ModelId, ids.TransmissionTypeId),
                    m => m.AvailableTransmissionTypes.Select(i => i.Id)))
            .OverridePropertyName("ModelIdTransmissionTypeId")
            .WithMessage("Such transmission type is not contained by the given model!");
        
        RuleFor(x => new { x.ModelId, x.DrivetrainTypeId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleModel, VehicleDrivetrainType>(
                    unitOfWork, (ids.ModelId, ids.DrivetrainTypeId), m => m.AvailableDrivetrainTypes.Select(i => i.Id)))
            .OverridePropertyName("ModelIdDrivetrainTypeId")
            .WithMessage("Such drivetrain type is not contained by the given model!");
        
        RuleFor(x => x.LocationRegionId)
            .NotEmpty()
            .MustAsync(async (regionId, _) => 
                await validationHelper.CheckMainAspectPresence<VehicleLocationRegion>(unitOfWork, regionId))
            .WithMessage("Such region doesn't exists!");
        
        RuleFor(x => x.LocationAreaId)
            .NotEmpty()
            .MustAsync(async (areaId, _) => 
                await validationHelper.CheckMainAspectPresence<VehicleLocationArea>(unitOfWork, areaId))
            .WithMessage("Such area doesn't exists!");
        
        RuleFor(x => x.LocationTownId)
            .NotEmpty()
            .MustAsync(async (townId, _) => 
                await validationHelper.CheckMainAspectPresence<VehicleLocationTown>(unitOfWork, townId))
            .WithMessage("Such town doesn't exists!");
        
        RuleFor(x => new { x.LocationRegionId, x.LocationAreaId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleLocationRegion, VehicleLocationArea>(
                    unitOfWork, (ids.LocationRegionId, ids.LocationAreaId), r => r.RelatedAreas.Select(i => i.Id)))
            .OverridePropertyName("LocationRegionIdLocationAreaId")
            .WithMessage("Such area is not contained by the given region!");
        
        RuleFor(x => new { x.LocationRegionId, x.LocationTownId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleLocationRegion, VehicleLocationTown>(
                    unitOfWork, (ids.LocationRegionId, ids.LocationTownId), r => r.RelatedTowns.Select(i => i.Id)))
            .OverridePropertyName("LocationRegionIdLocationTownId")
            .WithMessage("Such town is not contained by the given region!");
        
        RuleFor(x => new { x.LocationRegionId, x.LocationTownId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleLocationTown, VehicleLocationRegion>(
                    unitOfWork, (ids.LocationRegionId, ids.LocationTownId), r => r.LocationRegion.Id))
            .OverridePropertyName("LocationTownIdLocationRegionId")
            .WithMessage("Such region is not related to the given town!");
        
        RuleFor(x => new { x.LocationTownId, x.LocationAreaId })
            .NotEmpty()
            .MustAsync(async (ids, _) => 
                await validationHelper.CheckSecondaryAspectPresence<VehicleLocationTown, VehicleLocationRegion>(
                    unitOfWork, (ids.LocationTownId, ids.LocationAreaId), r => r.LocationArea.Id))
            .OverridePropertyName("LocationTownIdLocationAreaId")
            .WithMessage("Such area is not related to the given town!");
    }
}
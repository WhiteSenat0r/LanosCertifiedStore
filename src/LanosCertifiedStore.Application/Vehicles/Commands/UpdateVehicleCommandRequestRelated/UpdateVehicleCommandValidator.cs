namespace LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicleCommandRequestRelated;

// TODO
// internal sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
// {
//     public UpdateVehicleCommandValidator(IUnitOfWork unitOfWork, IValidationHelper inputValidationService)
//     {
//         RuleFor(x => x.Description)
//             .NotEmpty()
//             .MinimumLength(20)
//             .MaximumLength(3000)
//             .WithMessage("Description must be greater than 20 characters and less than 3000!");
//
//         RuleFor(x => x.Price)
//             .NotEmpty()
//             .GreaterThan(0)
//             .WithMessage("Price must be greater than 0 $USD!");
//         
//         RuleFor(x => x.Displacement)
//             .NotEmpty()
//             .WithMessage("Engine's displacement must be greater than 0 liters!");
//
//         RuleFor(x => x.ModelId)
//             .NotEmpty()
//             .MustAsync(async (modelId, _) => 
//                 await inputValidationService.CheckMainAspectPresence<VehicleModel>(unitOfWork, modelId))
//             .WithMessage("Such model doesn't exists!");
//         
//         RuleFor(x => new { x.ModelId, x.BodyTypeId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleModel, VehicleBodyType>(
//                     unitOfWork, (ids.ModelId, ids.BodyTypeId), m => m.AvailableBodyTypes.Select(i => i.Id)))
//             .OverridePropertyName("ModelIdBodyTypeId")
//             .WithMessage("Such body type is not contained by the given model!");
//         
//         RuleFor(x => new { x.ModelId, x.EngineTypeId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleModel, VehicleEngineType>(
//                     unitOfWork, (ids.ModelId, ids.EngineTypeId), m => m.AvailableEngineTypes.Select(i => i.Id)))
//             .OverridePropertyName("ModelIdEngineTypeId")
//             .WithMessage("Such engine type is not contained by the given model!");
//         
//         RuleFor(x => new { x.ModelId, x.TransmissionTypeId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleModel, VehicleTransmissionType>(
//                     unitOfWork, (ids.ModelId, ids.TransmissionTypeId),
//                     m => m.AvailableTransmissionTypes.Select(i => i.Id)))
//             .OverridePropertyName("ModelIdTransmissionTypeId")
//             .WithMessage("Such transmission type is not contained by the given model!");
//         
//         RuleFor(x => new { x.ModelId, x.DrivetrainTypeId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleModel, VehicleDrivetrainType>(
//                     unitOfWork, (ids.ModelId, ids.DrivetrainTypeId), m => m.AvailableDrivetrainTypes.Select(i => i.Id)))
//             .OverridePropertyName("ModelIdDrivetrainTypeId")
//             .WithMessage("Such drivetrain type is not contained by the given model!");
//         
//         RuleFor(x => x.LocationRegionId)
//             .NotEmpty()
//             .MustAsync(async (regionId, _) => 
//                 await inputValidationService.CheckMainAspectPresence<VehicleLocationRegion>(unitOfWork, regionId))
//             .WithMessage("Such region doesn't exists!");
//         
//         RuleFor(x => x.LocationAreaId)
//             .NotEmpty()
//             .MustAsync(async (areaId, _) => 
//                 await inputValidationService.CheckMainAspectPresence<VehicleLocationArea>(unitOfWork, areaId))
//             .WithMessage("Such area doesn't exists!");
//         
//         RuleFor(x => x.LocationTownId)
//             .NotEmpty()
//             .MustAsync(async (townId, _) => 
//                 await inputValidationService.CheckMainAspectPresence<VehicleLocationTown>(unitOfWork, townId))
//             .WithMessage("Such town doesn't exists!");
//         
//         RuleFor(x => new { x.LocationRegionId, x.LocationAreaId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleLocationRegion, VehicleLocationArea>(
//                     unitOfWork, (ids.LocationRegionId, ids.LocationAreaId), r => r.RelatedAreas.Select(i => i.Id)))
//             .OverridePropertyName("LocationRegionIdLocationAreaId")
//             .WithMessage("Such area is not contained by the given region!");
//         
//         RuleFor(x => new { x.LocationRegionId, x.LocationTownId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleLocationRegion, VehicleLocationTown>(
//                     unitOfWork, (ids.LocationRegionId, ids.LocationTownId), r => r.RelatedTowns.Select(i => i.Id)))
//             .OverridePropertyName("LocationRegionIdLocationTownId")
//             .WithMessage("Such town is not contained by the given region!");
//         
//         RuleFor(x => new { x.LocationRegionId, x.LocationTownId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleLocationTown, VehicleLocationRegion>(
//                     unitOfWork, (ids.LocationRegionId, ids.LocationTownId), r => r.LocationRegion.Id))
//             .OverridePropertyName("LocationTownIdLocationRegionId")
//             .WithMessage("Such region is not related to the given town!");
//         
//         RuleFor(x => new { x.LocationTownId, x.LocationAreaId })
//             .NotEmpty()
//             .MustAsync(async (ids, _) => 
//                 await inputValidationService.CheckSecondaryAspectPresence<VehicleLocationTown, VehicleLocationRegion>(
//                     unitOfWork, (ids.LocationTownId, ids.LocationAreaId), r => r.LocationArea.Id))
//             .OverridePropertyName("LocationTownIdLocationAreaId")
//             .WithMessage("Such area is not related to the given town!");
//     }
// }
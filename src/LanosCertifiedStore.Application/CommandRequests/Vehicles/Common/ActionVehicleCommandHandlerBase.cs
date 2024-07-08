namespace Application.CommandRequests.Vehicles.Common;

// TODO
// internal abstract class ActionVehicleCommandHandlerBase<TResult>(
//     IUnitOfWork unitOfWork) : CommandHandlerBase<TResult>(unitOfWork) 
//     where TResult : struct
// {
//     private protected async Task<Result<Vehicle>> CreateVehicleInstance(IActionVehicleCommandBase request)
//     {
//         var aspects = await GetVehicleAspects(request);
//
//         foreach (var aspect in aspects.Where(aspect => aspect.Value is null))
//             return GetFailureResult(aspect.Key);
//
//         var vehicle = GetVehicleInstanceByCommandData(
//             (aspects["Model"] as VehicleModel)!,
//             (aspects["Color"] as VehicleColor)!,
//             (aspects["Body type"] as VehicleBodyType)!,
//             (aspects["Engine type"] as VehicleEngineType)!,
//             (aspects["Transmission type"] as VehicleTransmissionType)!,
//             (aspects["Drivetrain type"] as VehicleDrivetrainType)!,
//             (aspects["Region"] as VehicleLocationRegion)!,
//             (aspects["Area"] as VehicleLocationArea)!,
//             (aspects["Town"] as VehicleLocationTown)!,
//             request);
//
//         return Result<Vehicle>.Success(vehicle);
//     }
//
//     private async Task<Dictionary<string, IIdentifiable<Guid>?>> GetVehicleAspects(
//         IActionVehicleCommandBase request) =>
//         new()
//         {
//             { "Model", await GetAspectDataAsync<VehicleModel>(request.ModelId) },
//             { "Color", await GetAspectDataAsync<VehicleColor>(request.ColorId) },
//             { "Body type", await GetAspectDataAsync<VehicleBodyType>(request.BodyTypeId) },
//             { "Engine type", await GetAspectDataAsync<VehicleEngineType>(request.EngineTypeId) },
//             { "Transmission type", await GetAspectDataAsync<VehicleTransmissionType>(request.TransmissionTypeId) },
//             { "Drivetrain type", await GetAspectDataAsync<VehicleDrivetrainType>(request.DrivetrainTypeId) },
//             { "Region", await GetAspectDataAsync<VehicleLocationRegion>(request.LocationRegionId) },
//             { "Area", await GetAspectDataAsync<VehicleLocationArea>(request.LocationAreaId) },
//             { "Town", await GetAspectDataAsync<VehicleLocationTown>(request.LocationTownId) },
//         };
//
//     private Vehicle GetVehicleInstanceByCommandData(
//         VehicleModel vehicleModel,
//         VehicleColor vehicleColor,
//         VehicleBodyType vehicleBodyType,
//         VehicleEngineType vehicleEngineType,
//         VehicleTransmissionType vehicleTransmissionType,
//         VehicleDrivetrainType vehicleDrivetrainType,
//         VehicleLocationRegion vehicleLocationRegion,
//         VehicleLocationArea vehicleLocationArea,
//         VehicleLocationTown vehicleLocationTown,
//         IActionVehicleCommandBase vehicleData) =>
//         new(
//             brand: vehicleModel.Brand,
//             model: vehicleModel,
//             color: vehicleColor,
//             vehicleType: vehicleModel.VehicleType,
//             price: vehicleData.Price,
//             displacement: vehicleData.Displacement,
//             description: vehicleData.Description,
//             bodyType: vehicleBodyType,
//             engineType: vehicleEngineType,
//             transmissionType: vehicleTransmissionType,
//             drivetrainType: vehicleDrivetrainType,
//             locationArea: vehicleLocationArea,
//             locationRegion: vehicleLocationRegion,
//             locationTown: vehicleLocationTown,
//             mileage: vehicleData.Mileage,
//             productionYear: vehicleData.ProductionYear
//         );
//
//     private Task<TAspect?> GetAspectDataAsync<TAspect>(Guid id)
//         where TAspect : IIdentifiable<Guid> =>
//         unitOfWork.RetrieveRepository<TAspect>().GetEntityByIdAsync(id);
//
//     private Result<Vehicle> GetFailureResult(string aspect) =>
//         Result<Vehicle>.Failure(
//             new Error("NotFound", $"Such {aspect.ToLower()} doesn't exists!"));
// }
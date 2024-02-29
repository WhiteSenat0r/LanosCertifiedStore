using Application.Commands.Vehicles.CreateVehicle;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;

namespace Application.Commands.Vehicles.Common;

internal abstract class ActionVehicleCommandHandlerBase
{
    private protected async Task<Result<Vehicle>> CreateVehicleBaseInstance(
        IUnitOfWork unitOfWork,
        IActionVehicleCommandBase request)
    {
        var vehicleModel = await GetAspectDataAsync<VehicleModel>(unitOfWork, request.ModelId);
        if (vehicleModel is null) return GetFailureResult("Model");

        var vehicleBrand = await GetAspectDataAsync<VehicleBrand>(unitOfWork, vehicleModel.Brand.Id);
        if (vehicleBrand is null) return GetFailureResult("Brand");

        var vehicleColor = await GetAspectDataAsync<VehicleColor>(unitOfWork, request.ColorId);
        if (vehicleColor is null) return GetFailureResult("Color");

        var vehicleType = await GetAspectDataAsync<VehicleType>(unitOfWork, request.TypeId);
        if (vehicleType is null) return GetFailureResult("Type");

        var vehicle = InstantiateVehicleObject(vehicleBrand, vehicleModel, vehicleColor, vehicleType, request);

        return Result<Vehicle>.Success(vehicle);
    }

    private Vehicle InstantiateVehicleObject(
        VehicleBrand vehicleBrand,
        VehicleModel vehicleModel,
        VehicleColor vehicleColor,
        VehicleType vehicleType,
        IActionVehicleCommandBase vehicleData)
    {
        if (vehicleData is CreateVehicleCommand createVehicleCommand)
            return new Vehicle(
                brand: vehicleBrand,
                model: vehicleModel,
                color: vehicleColor,
                type: vehicleType,
                price: createVehicleCommand.Price,
                displacement: createVehicleCommand.Displacement,
                description: createVehicleCommand.Description
            );

        return new Vehicle(
            brand: vehicleBrand,
            model: vehicleModel,
            color: vehicleColor,
            type: vehicleType,
            price: vehicleData.Price,
            displacement: vehicleData.Displacement,
            description: vehicleData.Description
        );
    }

    private Task<TAspect?> GetAspectDataAsync<TAspect>(IUnitOfWork unitOfWork, Guid id)
        where TAspect : IIdentifiable<Guid> =>
        unitOfWork.RetrieveRepository<TAspect>().GetEntityByIdAsync(id);

    private Result<Vehicle> GetFailureResult(string aspect) =>
        Result<Vehicle>.Failure(
            new Error("NotFound", $"Such {aspect.ToLower()} doesn't exists!"));
}
using Application.Commands.Common;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;

namespace Application.Commands.Vehicles.Common;

internal abstract class ActionVehicleCommandHandlerBase<TResult>(
    IUnitOfWork unitOfWork) : CommandHandlerBase<TResult>(unitOfWork) 
    where TResult : struct
{
    private protected async Task<Result<Vehicle>> CreateVehicleInstance(IActionVehicleCommandBase request)
    {
        var vehicleModel = await GetAspectDataAsync<VehicleModel>(request.ModelId);
        if (vehicleModel is null) return GetFailureResult("Model");

        var vehicleColor = await GetAspectDataAsync<VehicleColor>(request.ColorId);
        if (vehicleColor is null) return GetFailureResult("Color");

        var vehicleType = await GetAspectDataAsync<VehicleType>(request.TypeId);
        if (vehicleType is null) return GetFailureResult("Type");

        var vehicle = GetVehicleInstanceByCommandData(
            vehicleModel.Brand, vehicleModel, vehicleColor, vehicleType, request);

        return Result<Vehicle>.Success(vehicle);
    }

    private Vehicle GetVehicleInstanceByCommandData(
        VehicleBrand vehicleBrand, 
        VehicleModel vehicleModel,
        VehicleColor vehicleColor, 
        VehicleType vehicleType, 
        IActionVehicleCommandBase vehicleData) =>
        new(
            // TODO
            // brand: vehicleBrand,
            // model: vehicleModel,
            // color: vehicleColor,
            // vehicleType: vehicleType,
            // price: vehicleData.Price,
            // displacement: vehicleData.Displacement,
            // description: vehicleData.Description
        );

    private Task<TAspect?> GetAspectDataAsync<TAspect>(Guid id)
        where TAspect : IIdentifiable<Guid> =>
        unitOfWork.RetrieveRepository<TAspect>().GetEntityByIdAsync(id);

    private Result<Vehicle> GetFailureResult(string aspect) =>
        Result<Vehicle>.Failure(
            new Error("NotFound", $"Such {aspect.ToLower()} doesn't exists!"));
}
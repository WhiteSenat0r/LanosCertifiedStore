using Application.Dtos.VehicleDtos;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.Common;

internal abstract class ActionVehicleCommandBase
{
    private protected const string PathTemplate = "LanosCertifiedStore/Vehicles";
    
    private protected async Task<Result<Vehicle>> CreateVehicleBaseInstance<TCommand>(
        TCommand request, IUnitOfWork unitOfWork) 
        where TCommand : IRequest<Result<Unit>>
    {
        var vehicleData = GetActionVehicleDto(request);

        var vehicleModel = await GetAspectDataAsync<VehicleModel>(unitOfWork, vehicleData!.ModelId);
        if (vehicleModel is null) return GetFailureResult("Model");

        var vehicleBrand = await GetAspectDataAsync<VehicleBrand>(unitOfWork, vehicleData.BrandId);
        if (vehicleBrand is null) return GetFailureResult("Brand");

        var vehicleColor = await GetAspectDataAsync<VehicleColor>(unitOfWork, vehicleData.ColorId);
        if (vehicleColor is null) return GetFailureResult("Color");

        var vehicleType = await GetAspectDataAsync<VehicleType>(unitOfWork, vehicleData.TypeId);
        if (vehicleType is null) return GetFailureResult("Type");

        var vehicle = InstantiateVehicleObject(vehicleBrand, vehicleModel, vehicleColor, vehicleType, vehicleData);

        return Result<Vehicle>.Success(vehicle);
    }

    private Vehicle InstantiateVehicleObject(
        VehicleBrand vehicleBrand,
        VehicleModel vehicleModel,
        VehicleColor vehicleColor,
        VehicleType vehicleType,
        ActionVehicleDto vehicleData)
    {
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

    private ActionVehicleDto? GetActionVehicleDto<TCommand>(TCommand request)
    {
        var requestParamsProperty = request!.GetType().GetProperties().FirstOrDefault(
            p => p.PropertyType == typeof(ActionVehicleDto));

        return requestParamsProperty?.GetValue(request) as ActionVehicleDto;
    }
    
    private Task<TAspect?> GetAspectDataAsync<TAspect>(IUnitOfWork unitOfWork, Guid id) 
        where TAspect : IEntity<Guid> => 
        unitOfWork.RetrieveRepository<TAspect>().GetEntityByIdAsync(id);

    private Result<Vehicle> GetFailureResult(string aspect) =>
        Result<Vehicle>.Failure(
            new Error("NotFound", $"Such {aspect.ToLower()} doesn't exists!"));
}
using Application.Shared.DtosRelated;
using Application.VehicleModels.Commands.CreateVehicleModelRelated;
using Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using Application.VehicleModels.Dtos;
using Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;

namespace Application.VehicleModels;

public interface IVehicleModelService
{
    Task<IReadOnlyCollection<VehicleModelDto>> GetVehicleModelCollection(
        CollectionVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<VehicleModelWithoutBrandNameDto>> GetVehicleBrandlessModelCollection(
        CollectionVehicleBrandlessModelsQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<SingleVehicleModelDto?> GetSingleVehicleModel(
        SingleVehicleModelQueryRequest queryRequest,
        CancellationToken cancellationToken);
    
    Task<ItemsCountDto> GetVehicleModelsCount(
        CountVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<Guid> AddNewVehicleModel(CreateVehicleModelCommandRequest request, CancellationToken cancellationToken);
    
    Task UpdateVehicleModel(UpdateVehicleModelCommandRequest request, CancellationToken cancellationToken);
}
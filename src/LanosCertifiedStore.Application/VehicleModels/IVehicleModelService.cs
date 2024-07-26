using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.CreateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;
using LanosCertifiedStore.Application.VehicleModels.Dtos;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleBrandlessModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CollectionVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.CountVehicleModelsQueryRelated;
using LanosCertifiedStore.Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;

namespace LanosCertifiedStore.Application.VehicleModels;

public interface IVehicleModelService
{
    Task<IReadOnlyCollection<VehicleModelDto>> GetVehicleModelCollection(
        CollectionVehicleModelsQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<IReadOnlyCollection<VehicleModelWithoutBrandNameDto>> GetVehicleBrandlessModelCollection(
        CollectionBrandlessVehicleModelsQueryRequest queryRequest,
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
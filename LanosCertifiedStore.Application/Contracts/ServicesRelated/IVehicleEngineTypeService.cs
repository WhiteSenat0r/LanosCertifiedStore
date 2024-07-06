using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CountVehicleEngineTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleEngineTypeService
{
    Task<IReadOnlyCollection<VehicleEngineTypeDto>> GetVehicleEngineTypeCollection(
        CollectionVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleEngineTypesCount(
        CountVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
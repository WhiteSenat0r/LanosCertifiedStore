using Application.Contracts.ServicesRelated;
using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CountVehicleEngineTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleEngineTypeService(
    CollectionVehicleEngineTypesQuery collectionVehicleEngineTypesQuery,
    CountVehicleEngineTypesQuery countVehicleEngineTypesQuery) : IVehicleEngineTypeService
{
    public async Task<IReadOnlyCollection<VehicleEngineTypeDto>> GetVehicleEngineTypeCollection(
        CollectionVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleEngineTypesQuery.Execute(queryRequest, cancellationToken);
    }

    public async Task<ItemsCountDto> GetVehicleEngineTypesCount(CountVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await countVehicleEngineTypesQuery.Execute(queryRequest, cancellationToken);
    }
}
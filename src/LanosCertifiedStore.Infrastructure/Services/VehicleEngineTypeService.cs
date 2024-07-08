using Application.Contracts.ServicesRelated;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleEngineTypeRelated.CollectionVehicleEngineTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleEngineTypeService(
    CollectionVehicleEngineTypesQuery collectionVehicleEngineTypesQuery) : IVehicleEngineTypeService
{
    public async Task<IReadOnlyCollection<VehicleEngineTypeDto>> GetVehicleEngineTypeCollection(
        CollectionVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleEngineTypesQuery.Execute(queryRequest, cancellationToken);
    }
}
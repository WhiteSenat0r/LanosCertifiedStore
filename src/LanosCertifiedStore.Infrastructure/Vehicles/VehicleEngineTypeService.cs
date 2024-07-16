using Application.VehicleEngineTypes;
using Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;

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
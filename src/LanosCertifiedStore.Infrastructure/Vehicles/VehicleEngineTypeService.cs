using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;
using LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Vehicles;

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
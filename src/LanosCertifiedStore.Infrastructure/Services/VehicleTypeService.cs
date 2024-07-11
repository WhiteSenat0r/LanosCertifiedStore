using Application.VehicleTypes;
using Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services;

internal sealed class VehicleTypeService(
    CollectionVehicleTypesQuery collectionQuery) : IVehicleTypeService
{
    public async Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }
}
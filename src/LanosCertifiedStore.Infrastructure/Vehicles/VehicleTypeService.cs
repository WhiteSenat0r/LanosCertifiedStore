using LanosCertifiedStore.Application.VehicleTypes;
using LanosCertifiedStore.Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;
using LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Vehicles;

internal sealed class VehicleTypeService(
    CollectionVehicleTypesQuery collectionQuery) : IVehicleTypeService
{
    public async Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        return await collectionQuery.Execute(queryRequest, cancellationToken);
    }
}
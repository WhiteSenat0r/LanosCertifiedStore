using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Vehicles;

internal sealed class VehicleBodyTypeService(
    CollectionVehicleBodyTypesQuery collectionVehicleBodyTypesQuery) : IVehicleBodyTypeService
{
    public async Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleBodyTypesQuery.Execute(queryRequest, cancellationToken);
    }
}
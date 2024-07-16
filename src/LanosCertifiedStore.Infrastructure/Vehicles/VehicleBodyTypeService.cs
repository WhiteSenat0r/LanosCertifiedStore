using Application.VehicleBodyTypes;
using Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;

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
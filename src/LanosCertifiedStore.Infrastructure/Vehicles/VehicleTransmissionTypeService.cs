using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;
using LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleTransmissionTypeService(
    CollectionVehicleTransmissionTypesQuery collectionVehicleTransmissionTypesQuery) : IVehicleTransmissionTypeService
{
    public async Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken)
    {
        return await collectionVehicleTransmissionTypesQuery.Execute(queryRequest, cancellationToken);
    }
}
using Application.VehicleTransmissionTypes;
using Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;
using Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Vehicles;

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
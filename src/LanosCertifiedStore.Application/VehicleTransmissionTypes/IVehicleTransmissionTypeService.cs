using LanosCertifiedStore.Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

namespace LanosCertifiedStore.Application.VehicleTransmissionTypes;

public interface IVehicleTransmissionTypeService
{
    Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
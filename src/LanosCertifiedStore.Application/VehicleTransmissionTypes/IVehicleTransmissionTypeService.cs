using Application.VehicleTransmissionTypes.Queries.CollectionVehicleTransmissionTypesQueryRelated;

namespace Application.VehicleTransmissionTypes;

public interface IVehicleTransmissionTypeService
{
    Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
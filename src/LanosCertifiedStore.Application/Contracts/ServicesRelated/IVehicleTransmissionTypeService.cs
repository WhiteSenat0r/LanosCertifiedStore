using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CollectionVehicleTransmissionTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleTransmissionTypeService
{
    Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
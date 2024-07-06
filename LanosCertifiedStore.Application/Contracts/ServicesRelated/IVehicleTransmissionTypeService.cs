using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CollectionVehicleTransmissionTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated.CountTransmissionTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleTransmissionTypeService
{
    Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> GetVehicleTransmissionTypeCollection(
        CollectionVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleTransmissionTypesCount(
        CountVehicleTransmissionTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
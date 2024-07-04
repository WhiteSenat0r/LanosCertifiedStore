using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CountVehicleTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleTypeService
{
    Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleTypesCount(
        CountVehicleTypesQueryRequest queryRequest, CancellationToken cancellationToken);
}
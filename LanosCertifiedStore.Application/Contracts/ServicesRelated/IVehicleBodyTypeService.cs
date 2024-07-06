using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CountBodyTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleBodyTypeService
{
    Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleBodyTypesCount(
        CountVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
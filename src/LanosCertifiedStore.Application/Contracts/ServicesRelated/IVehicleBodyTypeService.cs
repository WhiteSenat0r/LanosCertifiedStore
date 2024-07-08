using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleBodyTypeRelated.CollectionVehicleBodyTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleBodyTypeService
{
    Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
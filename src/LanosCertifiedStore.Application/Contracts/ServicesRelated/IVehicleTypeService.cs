using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleTypeRelated.CollectionVehicleTypesQueryRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleTypeService
{
    Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
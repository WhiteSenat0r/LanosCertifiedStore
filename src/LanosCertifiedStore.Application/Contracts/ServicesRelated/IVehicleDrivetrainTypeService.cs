using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleDrivetrainTypeService
{
    Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> GetVehicleDrivetrainTypeCollection(
        CollectionVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
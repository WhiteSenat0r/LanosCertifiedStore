using Application.Dtos.Common;
using Application.Dtos.TypeDtos;
using Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.
    CollectionVehicleDrivetrainTypesQueryRequestRelated;
using
    Application.QueryRequests.TypesRelated.VehicleDrivetrainTypeRelated.CountVehicleDrivetrainTypesQueryRequestRelated;

namespace Application.Contracts.ServicesRelated;

public interface IVehicleDrivetrainTypeService
{
    Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> GetVehicleDrivetrainTypeCollection(
        CollectionVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);

    Task<ItemsCountDto> GetVehicleTypesCount(CountVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
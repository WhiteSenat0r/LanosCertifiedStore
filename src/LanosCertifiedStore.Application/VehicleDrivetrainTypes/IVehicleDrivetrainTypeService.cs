using LanosCertifiedStore.Application.VehicleDrivetrainTypes.Queries.CollectionVehicleDrivetrainTypesQueryRequestRelated;

namespace LanosCertifiedStore.Application.VehicleDrivetrainTypes;

public interface IVehicleDrivetrainTypeService
{
    Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> GetVehicleDrivetrainTypeCollection(
        CollectionVehicleDrivetrainTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
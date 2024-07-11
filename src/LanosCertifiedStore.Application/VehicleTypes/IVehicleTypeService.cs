using Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

namespace Application.VehicleTypes;

public interface IVehicleTypeService
{
    Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
using LanosCertifiedStore.Application.VehicleTypes.Queries.CollectionVehicleTypesQueryRelated;

namespace LanosCertifiedStore.Application.VehicleTypes;

public interface IVehicleTypeService
{
    Task<IReadOnlyCollection<VehicleTypeDto>> GetVehicleTypeCollection(
        CollectionVehicleTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
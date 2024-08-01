using LanosCertifiedStore.Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

namespace LanosCertifiedStore.Application.VehicleEngineTypes;

public interface IVehicleEngineTypeService
{
    Task<IReadOnlyCollection<VehicleEngineTypeDto>> GetVehicleEngineTypeCollection(
        CollectionVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
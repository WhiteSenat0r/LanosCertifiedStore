using Application.VehicleEngineTypes.Queries.CollectionVehicleEngineTypesQueryRelated;

namespace Application.VehicleEngineTypes;

public interface IVehicleEngineTypeService
{
    Task<IReadOnlyCollection<VehicleEngineTypeDto>> GetVehicleEngineTypeCollection(
        CollectionVehicleEngineTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
using LanosCertifiedStore.Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

namespace LanosCertifiedStore.Application.VehicleBodyTypes;

public interface IVehicleBodyTypeService
{
    Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
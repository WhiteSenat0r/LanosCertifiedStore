using Application.VehicleBodyTypes.Queries.CollectionVehicleBodyTypesQueryRelated;

namespace Application.VehicleBodyTypes;

public interface IVehicleBodyTypeService
{
    Task<IReadOnlyCollection<VehicleBodyTypeDto>> GetVehicleBodyTypeCollection(
        CollectionVehicleBodyTypesQueryRequest queryRequest,
        CancellationToken cancellationToken);
}
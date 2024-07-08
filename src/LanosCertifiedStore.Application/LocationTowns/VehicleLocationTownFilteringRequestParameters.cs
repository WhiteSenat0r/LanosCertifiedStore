using Application.Shared.RequestParamsRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationTowns;

public sealed class VehicleLocationTownFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationTown>, ILocationTownFilteringRequestParameters
{
    public Guid? LocationRegionId { get; init; }
    public Guid? LocationTownTypeId { get; init; }
}
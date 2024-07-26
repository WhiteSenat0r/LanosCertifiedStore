using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationTowns;

public sealed class VehicleLocationTownFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationTown>, ILocationTownFilteringRequestParameters
{
    public Guid? LocationRegionId { get; init; }
    public Guid? LocationTownTypeId { get; init; }
}
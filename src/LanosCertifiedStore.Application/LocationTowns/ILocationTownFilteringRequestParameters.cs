using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationTowns;

public interface ILocationTownFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationTown>
{
    Guid? LocationRegionId { get; }
    Guid? LocationTownTypeId { get; }
}
using Application.Shared.RequestParamsRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationTowns;

public interface ILocationTownFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationTown>
{
    Guid? LocationRegionId { get; }
    Guid? LocationTownTypeId { get; }
}
using Application.Contracts.Common;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface ILocationTownFilteringRequestParameters : IFilteringRequestParameters<VehicleLocationTown>
{
    Guid? LocationRegionId { get; }
    Guid? LocationTownTypeId { get; }
}
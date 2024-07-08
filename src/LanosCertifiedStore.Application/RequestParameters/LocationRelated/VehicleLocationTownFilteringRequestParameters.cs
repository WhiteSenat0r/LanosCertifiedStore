using Application.Contracts.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.RequestParameters.LocationRelated;

public sealed class VehicleLocationTownFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationTown>, ILocationTownFilteringRequestParameters
{
    public Guid? LocationRegionId { get; init; }
    public Guid? LocationTownTypeId { get; init; }
}
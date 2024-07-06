using Application.Contracts.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.RequestParameters.LocationRelated;

public sealed class VehicleLocationAreaFilteringRequestParameters : 
    BaseFilteringRequestParameters<VehicleLocationArea>,
    ILocationAreaFilteringRequestParameters
{
    public Guid LocationRegionId { get; init; }
}
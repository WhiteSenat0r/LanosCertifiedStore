using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.Locations.LocationAreasRelated.CountLocationAreasQueryRequestRelated;

public sealed record CountLocationAreasQueryRequest(
    IFilteringRequestParameters<VehicleLocationArea> FilteringParameters) : ICountQueryRequest<VehicleLocationArea>;
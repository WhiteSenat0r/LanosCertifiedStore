using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;

public sealed record CountLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters) : 
    ICountQueryRequest<VehicleLocationTown>;
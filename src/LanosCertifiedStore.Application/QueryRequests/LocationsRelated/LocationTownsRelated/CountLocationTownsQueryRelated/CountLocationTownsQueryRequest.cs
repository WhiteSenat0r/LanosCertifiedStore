using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.LocationsRelated.LocationTownsRelated.CountLocationTownsQueryRelated;

public sealed record CountLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters) : 
    ICountQueryRequest<VehicleLocationTown>;
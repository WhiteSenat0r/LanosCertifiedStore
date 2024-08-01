using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;

public sealed record CountLocationTownsQueryRequest(
    IFilteringRequestParameters<VehicleLocationTown> FilteringParameters) : 
    ICountQueryRequest<VehicleLocationTown>;
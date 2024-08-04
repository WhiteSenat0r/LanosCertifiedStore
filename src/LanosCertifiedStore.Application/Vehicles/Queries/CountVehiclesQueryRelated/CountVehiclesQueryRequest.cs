using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CountVehiclesQueryRelated;

public sealed record CountVehiclesQueryRequest(IFilteringRequestParameters<Vehicle> FilteringParameters)
    : ICountQueryRequest<Vehicle>;
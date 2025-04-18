using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.CountUserVehiclesQueryRequestRelated;

public sealed record CountUserVehiclesQueryRequest(IFilteringRequestParameters<Vehicle> FilteringParameters)
    : ICountQueryRequest<Vehicle>;
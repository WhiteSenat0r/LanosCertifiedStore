using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.GetUserVehiclesQueryRequestRelated;

public sealed record GetUserVehiclesQueryRequest(IFilteringRequestParameters<Vehicle> FilteringParameters)
    : ICollectionQueryRequest<Vehicle, PaginationResult<VehicleDto>, VehicleDto>;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;

public sealed record CollectionVehiclesQueryRequest(IFilteringRequestParameters<Vehicle> FilteringParameters)
    : ICollectionQueryRequest<Vehicle, PaginationResult<VehicleDto>, VehicleDto>;
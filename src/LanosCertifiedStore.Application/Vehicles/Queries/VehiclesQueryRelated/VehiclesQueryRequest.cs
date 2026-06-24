using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles.Queries.VehiclesQueryRelated;

public sealed record VehiclesQueryRequest(
    IVehicleFilteringRequestParameters FilteringParameters) :
    ICollectionQueryRequest<Vehicle, PaginationResult<VehicleDto>, VehicleDto>;
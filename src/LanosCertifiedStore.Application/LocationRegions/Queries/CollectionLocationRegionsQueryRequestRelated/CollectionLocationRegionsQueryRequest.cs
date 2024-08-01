using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;

public sealed record CollectionLocationRegionsQueryRequest(
    IFilteringRequestParameters<VehicleLocationRegion> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationRegion, PaginationResult<LocationRegionDto>, LocationRegionDto>;
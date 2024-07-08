using Application.LocationRegions.Dtos;
using Application.Shared.RequestParamsRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;

public sealed record CollectionLocationRegionsQueryRequest(
    IFilteringRequestParameters<VehicleLocationRegion> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationRegion, PaginationResult<LocationRegionDto>, LocationRegionDto>;
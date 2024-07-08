using Application.Contracts.Common;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Domain.Entities.VehicleRelated.LocationRelated;

namespace Application.QueryRequests.LocationsRelated.LocationRegionsRelated.CollectionLocationRegionsQueryRequestRelated;

public sealed record CollectionLocationRegionsQueryRequest(
    IFilteringRequestParameters<VehicleLocationRegion> FilteringParameters)
    : ICollectionQueryRequest<VehicleLocationRegion, PaginationResult<LocationRegionDto>, LocationRegionDto>;
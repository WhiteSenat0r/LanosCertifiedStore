using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.LocationRegions.Queries.CollectionLocationRegionsQueryRequestRelated;

internal sealed class CollectionLocationTownsQueryRequestHandler(
    ILocationRegionService locationRegionService) :
    IRequestHandler<CollectionLocationRegionsQueryRequest, Result<PaginationResult<LocationRegionDto>>>
{
    public async Task<Result<PaginationResult<LocationRegionDto>>> Handle(
        CollectionLocationRegionsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var locationRegions = await locationRegionService.GetLocationRegionCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<LocationRegionDto>(
            locationRegions,
            request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}
using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.LocationDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.LocationsRelated.LocationRegionsRelated.CollectionLocationRegionsQueryRequestRelated;

internal sealed class CollectionLocationRegionsQueryRequestHandler(
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

        return Result<PaginationResult<LocationRegionDto>>.Success(paginationResult);
    }
}
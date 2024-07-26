using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CollectionLocationTownsQueryRequestRelated;

internal sealed class CollectionLocationTownsQueryRequestHandler(
    ILocationTownService locationTownService) :
    IRequestHandler<CollectionLocationTownsQueryRequest, Result<PaginationResult<LocationTownDto>>>
{
    public async Task<Result<PaginationResult<LocationTownDto>>> Handle(
        CollectionLocationTownsQueryRequest request,
        CancellationToken cancellationToken)
    {
        var locationTowns = await locationTownService.GetLocationTownCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<LocationTownDto>(
            locationTowns,
            request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}
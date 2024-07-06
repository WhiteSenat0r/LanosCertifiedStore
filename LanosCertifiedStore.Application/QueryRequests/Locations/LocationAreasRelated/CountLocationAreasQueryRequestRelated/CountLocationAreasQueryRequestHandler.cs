using Application.Contracts.RequestParametersRelated;
using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.Locations.LocationAreasRelated.CountLocationAreasQueryRequestRelated;

internal sealed class CountAreasQueryHandler(
    ILocationAreaService locationAreaService,
    ILocationRegionService locationRegionService) :
    IRequestHandler<CountLocationAreasQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountLocationAreasQueryRequest request,
        CancellationToken cancellationToken)
    {
        var requestParams = request.FilteringParameters as ILocationAreaFilteringRequestParameters;

        if (!await locationRegionService.ExistsById(requestParams!.LocationRegionId, cancellationToken))
        {
            return Result<ItemsCountDto>.Failure(Error.NotFound(requestParams.LocationRegionId));
        }

        var itemsCountDto = await locationAreaService.GetLocationAreasCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}
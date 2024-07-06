using Application.Contracts.RequestParametersRelated;
using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Core.Results;
using Application.Dtos.LocationDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.Locations.LocationAreasRelated.CollectionLocationAreasQueryRequestRelated;

internal sealed class VehicleLocationAreasQueryHandler(
    ILocationAreaService locationAreaService,
    ILocationRegionService locationRegionService) :
    IRequestHandler<CollectionLocationAreasQueryRequest, Result<PaginationResult<LocationAreaDto>>>
{
    public async Task<Result<PaginationResult<LocationAreaDto>>> Handle(
        CollectionLocationAreasQueryRequest request,
        CancellationToken cancellationToken)
    {
        var requestParams = request.FilteringParameters as ILocationAreaFilteringRequestParameters;

        if (!await locationRegionService.ExistsById(requestParams!.LocationRegionId, cancellationToken))
        {
            return Result<PaginationResult<LocationAreaDto>>.Failure(Error.NotFound(requestParams.LocationRegionId));
        }

        var locationAreas = await locationAreaService.GetLocationAreaCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<LocationAreaDto>(
            locationAreas,
            request.FilteringParameters.PageIndex);

        return Result<PaginationResult<LocationAreaDto>>.Success(paginationResult);
    }
}
using Application.Contracts.ServicesRelated.LocationRelated;
using Application.Dtos.Common;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.LocationsRelated.LocationTownsRelated.CountLocationTownsQueryRelated;

internal sealed class CountVehicleLocationTownsQueryRequestRequestHandler(ILocationTownService locationTownService) :
    IRequestHandler<CountLocationTownsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await locationTownService.GetLocationTownsCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(count);
    }
}
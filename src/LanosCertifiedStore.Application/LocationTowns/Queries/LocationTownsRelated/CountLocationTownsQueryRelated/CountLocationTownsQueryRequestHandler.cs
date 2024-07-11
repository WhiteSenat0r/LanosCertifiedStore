using Application.Shared.DtosRelated;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;

internal sealed class CountLocationTownsQueryRequestHandler(ILocationTownService locationTownService) :
    IRequestHandler<CountLocationTownsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await locationTownService.GetLocationTownsCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(count);
    }
}
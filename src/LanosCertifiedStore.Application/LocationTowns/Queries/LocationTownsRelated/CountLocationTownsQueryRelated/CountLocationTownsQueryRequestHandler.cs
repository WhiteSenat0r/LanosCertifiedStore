using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.LocationTowns.Queries.LocationTownsRelated.CountLocationTownsQueryRelated;

internal sealed class CountLocationTownsQueryRequestHandler(ILocationTownService locationTownService) :
    IRequestHandler<CountLocationTownsQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountLocationTownsQueryRequest request, CancellationToken cancellationToken)
    {
        var count = await locationTownService.GetLocationTownsCount(request, cancellationToken);

        return count;
    }
}
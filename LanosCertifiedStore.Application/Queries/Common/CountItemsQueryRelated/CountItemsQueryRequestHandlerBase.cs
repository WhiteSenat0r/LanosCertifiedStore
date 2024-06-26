using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Dtos.Common;
using Application.Shared;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Queries.Common.CountItemsQueryRelated;

internal abstract class CountItemsQueryRequestHandlerBase<TModel, TRequest, TQueryResult, TRequestResult>(
    IQueryService queryService) : IRequestHandler<TRequest, TRequestResult>
    where TRequest : CountItemsQueryRequestBase<TModel, TQueryResult, TRequestResult>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : Tuple<int, int>
    where TRequestResult : Result<ItemsCountDto>
{
    public async Task<TRequestResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var queryResult = await queryService.GetResult(request, cancellationToken);

        if (!queryResult.IsSuccess)
            return (Result<ItemsCountDto>.Failure(queryResult.Error!) as TRequestResult)!;

        var counts = new ItemsCountDto(queryResult.Value!.Item1, queryResult.Value.Item2);
        
        return (Result<ItemsCountDto>.Success(counts) as TRequestResult)!;
    }
}
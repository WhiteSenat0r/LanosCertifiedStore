using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Queries.Common.SingleQueryRelated;

internal abstract class SingleQueryRequestHandlerBase<TRequest, TModel, TQueryResult, TRequestResult, TDto>(
    IQueryService queryService,
    IMapper mapper) : IRequestHandler<TRequest, TRequestResult>
    where TRequest : SingleQueryRequestBase<TModel, TQueryResult, TRequestResult, TDto>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : TModel
    where TRequestResult : Result<TDto>
    where TDto : class
{
    public async Task<TRequestResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var queryResult = await queryService.GetResult(request, cancellationToken);

        if (!queryResult.IsSuccess)
            return (Result<TDto>.Failure(queryResult.Error!) as TRequestResult)!;

        var mappedItem = mapper.Map<TQueryResult, TDto>(queryResult.Value!);

        return (Result<TDto>.Success(mappedItem) as TRequestResult)!;
    }
}
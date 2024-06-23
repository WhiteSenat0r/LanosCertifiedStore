using Application.Contracts.ServicesRelated.RequestRelated;
using Application.Core.Results;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;
using MediatR;

namespace Application.Queries.Common.CollectionQueryRelated;

public abstract class CollectionQueryHandlerBase<TRequest, TModel, TQueryResult, TRequestResult, TDto>(
    IQueryService queryService,
    IMapper mapper) : IRequestHandler<TRequest, TRequestResult>
    where TRequest : CollectionQueryRequestBase<TModel, TQueryResult, TRequestResult, TDto>
    where TModel : class, IIdentifiable<Guid>
    where TQueryResult : IReadOnlyCollection<TModel>
    where TRequestResult : Result<PaginationResult<TDto>>
    where TDto : class
{
    public async Task<TRequestResult> Handle(TRequest request, CancellationToken cancellationToken)
    {
        var queryResult = await queryService.GetResult(request, cancellationToken);

        if (!queryResult.IsSuccess)
            return (Result<PaginationResult<TDto>>.Failure(queryResult.Error!) as TRequestResult)!;

        var mappedItems = mapper.Map<TQueryResult, IReadOnlyCollection<TDto>>(queryResult.Value!);

        var paginationResult = new PaginationResult<TDto>(
            mappedItems,
            request.FilteringParameters.PageIndex);

        return (Result<PaginationResult<TDto>>.Success(paginationResult) as TRequestResult)!;
    }
}
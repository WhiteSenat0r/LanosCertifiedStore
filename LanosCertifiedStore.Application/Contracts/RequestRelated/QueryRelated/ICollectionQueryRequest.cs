using Application.Core.Results;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Contracts.RequestRelated.QueryRelated;

public interface ICollectionQueryRequest<TModel, TQueryResult, TRequestResult, TDto> :
    IQueryRequest<TModel, TQueryResult, TRequestResult>
    where TModel : IIdentifiable<Guid>
    where TQueryResult : IReadOnlyCollection<TModel>
    where TRequestResult : Result<PaginationResult<TDto>>
    where TDto : class;
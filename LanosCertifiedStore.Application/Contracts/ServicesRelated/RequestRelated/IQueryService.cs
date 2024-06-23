using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared;
using Domain.Contracts.Common;

namespace Application.Contracts.ServicesRelated.RequestRelated;

public interface IQueryService
{
    Task<Result<TQueryResult>> GetResult<TModel, TQueryResult, TRequestResult>(
        IQueryRequest<TModel, TQueryResult, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TModel : class, IIdentifiable<Guid>
        where TQueryResult : notnull
        where TRequestResult : notnull;
}
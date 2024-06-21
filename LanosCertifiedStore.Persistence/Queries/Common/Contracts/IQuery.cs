using Application.Contracts.RequestRelated;
using Application.Shared;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuery<TModel, TResult>
    where TModel : class, IIdentifiable<Guid>
    where TResult : notnull
{
    Task<Result<TResult>> Execute<TQueryResult>(IQueryRequest<TModel, TResult, TQueryResult> queryRequest,
        CancellationToken cancellationToken) 
        where TQueryResult : notnull;
}
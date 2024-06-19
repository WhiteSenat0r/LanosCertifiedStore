using Application.Contracts.RequestRelated;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuery<TModel, TResult>
    where TModel : IIdentifiable<Guid>
    where TResult : notnull
{
    Task<TResult> Execute<TQueryResult>(IQueryRequest<TModel, TResult, TQueryResult> queryRequest,
        CancellationToken cancellationToken) 
        where TQueryResult : notnull;
}
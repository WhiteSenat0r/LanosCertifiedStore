using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared.ResultRelated;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQuery<TModel, TResult>
    where TModel : class, IIdentifiable<Guid>
    where TResult : notnull
{
    Task<Result<TResult>> Execute<TRequestResult>(
        IQueryRequest<TModel, TResult, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull;
}
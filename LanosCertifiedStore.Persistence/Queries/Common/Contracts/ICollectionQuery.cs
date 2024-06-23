using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface ICollectionQuery<TModel, TResult> : IQuery<TModel, TResult>
    where TModel : class, IIdentifiable<Guid>
    where TResult : IReadOnlyCollection<TModel>
{
    Task<Result<TResult>> Execute<TRequestResult>(
        IQueryRequest<TModel, IReadOnlyCollection<TModel>, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull;
}
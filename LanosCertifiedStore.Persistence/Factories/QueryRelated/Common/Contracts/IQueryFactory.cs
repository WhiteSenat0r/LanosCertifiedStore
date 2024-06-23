using Application.Contracts.RequestRelated.QueryRelated;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Factories.QueryRelated.Common.Contracts;

internal interface IQueryFactory
{
    IQuery<TModel, TResult> GetQuery<TModel, TResult, TQueryResult>(
        IQueryRequest<TModel, TResult, TQueryResult> queryRequest)
        where TModel : class, IIdentifiable<Guid>
        where TResult : notnull
        where TQueryResult : notnull;
}
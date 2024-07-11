using Application.Shared.RequestParamsRelated;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes;

internal sealed class QueryPaginator : IQueryPaginator
{
    public IQueryable<TEntity> ExecutePagination<TEntity>(
        IQueryable<TEntity> queryable, IFilteringRequestParameters<TEntity> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable
            .Skip((int)filteringRequestParameters.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take((int)filteringRequestParameters.ItemQuantity);
}
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes;

internal sealed class QueryPaginator : IQueryPaginator
{
    public IQueryable<TEntity> ExecutePagination<TEntity>(
        IQueryable<TEntity> queryable, IFilteringRequestParameters<TEntity> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable
            .Skip((int)filteringRequestParameters.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take((int)filteringRequestParameters.ItemQuantity);
}
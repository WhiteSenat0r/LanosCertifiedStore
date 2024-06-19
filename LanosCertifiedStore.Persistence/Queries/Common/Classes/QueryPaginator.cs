using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes;

internal sealed class QueryPaginator : IQueryPaginator
{
    public IQueryable<TEntity> ExecutePagination<TEntity, TModel>(
        IQueryable<TEntity> queryable, IFilteringRequestParameters<TModel> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid> =>
        queryable
            .Skip((int)filteringRequestParameters.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take((int)filteringRequestParameters.ItemQuantity);
}
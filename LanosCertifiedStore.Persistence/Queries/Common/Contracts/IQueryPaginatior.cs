using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

internal interface IQueryPaginator
{
    IQueryable<TEntity> ExecutePagination<TEntity, TModel>(
        IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TModel> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid>;
}
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;

namespace Persistence.Queries.Common.Contracts;

public interface IQueryPaginator
{
    IQueryable<TEntity> ExecutePagination<TEntity>(
        IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid>;
}
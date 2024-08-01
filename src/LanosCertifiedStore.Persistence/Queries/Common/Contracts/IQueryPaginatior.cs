using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Persistence.Queries.Common.Contracts;

public interface IQueryPaginator
{
    IQueryable<TEntity> ExecutePagination<TEntity>(
        IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid>;
}
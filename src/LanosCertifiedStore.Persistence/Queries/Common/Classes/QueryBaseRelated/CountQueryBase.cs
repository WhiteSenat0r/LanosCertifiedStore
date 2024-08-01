using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LanosCertifiedStore.Persistence.Queries.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class CountQueryBase<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    public abstract Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull;
    
    private protected IQueryable<TEntity> GetFilteredQueryable<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        IQueryable<TEntity> queryable,
        IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
        where TRequestResult : notnull
    {
        return queryable.GetQueryWithAppliedFilters(
            queryRequest.FilteringParameters, filteringCriteriaSelector!);
    }

    private protected IQueryable<TEntity> GetDatabaseQueryable(ApplicationDatabaseContext context)
    {
        var dataSet = context.Set<TEntity>();

        return dataSet.AsQueryable();
    }
    
    private protected async Task<ItemsCountDto> GetQueryResult(
        IQueryable<TEntity> totalQueryable,
        CancellationToken cancellationToken,
        IQueryable<TEntity>? filteredQueryable = null)
    {
        var totalItemsCountTask = await totalQueryable.CountAsync(cancellationToken);

        if (filteredQueryable is null)
        {
            return new ItemsCountDto(totalItemsCountTask, totalItemsCountTask);
        }
        
        var filteredItemsCountTask = await filteredQueryable.CountAsync(cancellationToken);

        return new ItemsCountDto(totalItemsCountTask, filteredItemsCountTask);
    }
}
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

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
        IQueryable<TEntity> filteredQueryable,
        CancellationToken cancellationToken)
    {
        var totalItemsCountTask = await totalQueryable.CountAsync(cancellationToken);
        var filteredItemsCountTask = await filteredQueryable.CountAsync(cancellationToken);

        return new ItemsCountDto(totalItemsCountTask, filteredItemsCountTask);
    }
}
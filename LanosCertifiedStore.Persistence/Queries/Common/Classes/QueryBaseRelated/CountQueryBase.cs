using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class CountQueryBase<TEntity>(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
    where TEntity : class, IIdentifiable<Guid>
{
    public async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull
    {
        var totalQueryable = GetDatabaseQueryable();
        var filteredQueryable = totalQueryable;

        filteredQueryable = filteredQueryable.GetQueryWithAppliedFilters(
            queryRequest.FilteringParameters, filteringCriteriaSelector);

        var executionResult = await GetQueryResult(totalQueryable, filteredQueryable, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();
        
        return dataSet.AsQueryable();
    }
    
    private async Task<ItemsCountDto> GetQueryResult(
        IQueryable<TEntity> totalQueryable,
        IQueryable<TEntity> filteredQueryable,
        CancellationToken cancellationToken)
    {
        var totalItemsCountTask = totalQueryable.CountAsync(cancellationToken);
        var filteredItemsCountTask = filteredQueryable.CountAsync(cancellationToken);

        var result = await Task.WhenAll([totalItemsCountTask, filteredItemsCountTask]);

        return new ItemsCountDto(result.First(), result.Last());
    }
}
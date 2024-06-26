using Application.Contracts.RequestRelated.QueryRelated;
using Application.Shared;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated.Constants;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

internal abstract class CountQueryBase<TModel, TEntity>(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<TModel, TEntity> filteringCriteriaSelector) : ICountQuery<TModel, Tuple<int, int>>
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
{
    public async Task<Result<Tuple<int, int>>> Execute<TRequestResult>(
        IQueryRequest<TModel, Tuple<int, int>, TRequestResult> queryRequest,
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
    
    private async Task<Result<Tuple<int, int>>> GetQueryResult(
        IQueryable<TEntity> totalQueryable,
        IQueryable<TEntity> filteredQueryable,
        CancellationToken cancellationToken)
    {
        try
        {
            var totalItemsCount = await totalQueryable.CountAsync(cancellationToken);
            var filteredItemsCount = await filteredQueryable.CountAsync(cancellationToken);
            
            return Result<Tuple<int, int>>.Success(new(totalItemsCount, filteredItemsCount));
        }
        catch (Exception)
        {
            return Result<Tuple<int, int>>.Failure(
                new Error(QueryConstants.QueryExecutionErrorCode, QueryConstants.QueryExecutionErrorMessage));
        }
    }
}
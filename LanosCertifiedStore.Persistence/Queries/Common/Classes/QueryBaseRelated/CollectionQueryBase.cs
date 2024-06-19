using Application.Contracts.RequestRelated;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated.Constants;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

internal abstract class CollectionQueryBase<TModel, TEntity>(
    ApplicationDatabaseContext context,
    IQuerySelectionProfileSelector<TEntity> selectionProfileSelector,
    IQuerySortingSettingsSelector<TEntity> sortingSettingsSelector,
    IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : IQuery<TModel, Result<IReadOnlyCollection<TModel>>>
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
{
    public async Task<Result<IReadOnlyCollection<TModel>>> Execute<TRequestResult>(
        IQueryRequest<TModel, Result<IReadOnlyCollection<TModel>>, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull
    {
        var queryable = GetDatabaseQueryable();

        queryable = queryable.GetQueryWithAppliedFilters(filteringCriteriaSelector);
        queryable = queryable.GetQueryWithAppliedSortingSettings(sortingSettingsSelector);
        queryable = queryable.GetQueryWithAppliedSelectionProfile(selectionProfileSelector);
        queryable = queryable.GetQueryWithAppliedPagination(queryPaginator, queryRequest.FilteringParameters);
        queryable = queryable.GetQueryWithAppliedTrackingSettings(queryRequest.IsTracked);

        var executionResult = await GetQueryResult(queryable, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();
        
        return dataSet.AsQueryable();
    }
    
    private async Task<Result<IReadOnlyCollection<TModel>>> GetQueryResult(
        IQueryable<TEntity> queryable,
        CancellationToken cancellationToken)
    {
        try
        {
            var items = (await queryable.ToListAsync(cancellationToken)).AsReadOnly();
            var mappedItems = mapper.Map<IReadOnlyCollection<TEntity>, IReadOnlyCollection<TModel>>(items);
            
            return Result<IReadOnlyCollection<TModel>>.Success(mappedItems);
        }
        catch (Exception)
        {
            return Result<IReadOnlyCollection<TModel>>.Failure(
                new Error(QueryConstants.QueryExecutionErrorCode, QueryConstants.QueryExecutionErrorMessage));
        }
    }
}
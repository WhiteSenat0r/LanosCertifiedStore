using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<TEntity> GetQueryWithAppliedFilters<TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters,
        IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable.Where(filteringCriteriaSelector.GetCriteria(filteringRequestParameters));
    
    public static IQueryable<TEntity> GetQueryWithAppliedSelectionProfile<TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters,
        IQueryProjectionProfileSelector<TEntity> projectionProfileSelector)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable.Select(projectionProfileSelector.GetProjectionProfile(filteringRequestParameters));

    public static IQueryable<TEntity> GetQueryWithAppliedSortingSettings<TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters,
        IQuerySortingSettingsSelector<TEntity> sortingSettingsSelector)
        where TEntity : class, IIdentifiable<Guid>
    {
        var sortingSettings = sortingSettingsSelector.GetSortingSettings(filteringRequestParameters);

        return sortingSettings.IsAscending
            ? queryable.OrderBy(sortingSettings.SortingSettings)
            : queryable.OrderByDescending(sortingSettings.SortingSettings);
    }
    
    public static IQueryable<TEntity> GetQueryWithAppliedPagination<TEntity>(
        this IQueryable<TEntity> queryable,
        IQueryPaginator queryPaginator,
        IFilteringRequestParameters<TEntity> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid> =>
        queryPaginator.ExecutePagination(
            queryable,
            filteringRequestParameters);
}
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<TEntity> GetQueryWithAppliedFilters<TEntity>(
        this IQueryable<TEntity> queryable,
        IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable.Where(filteringCriteriaSelector.GetCriteria());
    
    public static IQueryable<TEntity> GetQueryWithAppliedSelectionProfile<TEntity>(
        this IQueryable<TEntity> queryable,
        IQuerySelectionProfileSelector<TEntity> selectionProfileSelector)
        where TEntity : class, IIdentifiable<Guid> =>
        queryable.Select(selectionProfileSelector.GetSelectionProfile());

    public static IQueryable<TEntity> GetQueryWithAppliedSortingSettings<TEntity>(
        this IQueryable<TEntity> queryable,
        IQuerySortingSettingsSelector<TEntity> sortingSettingsSelector)
        where TEntity : class, IIdentifiable<Guid>
    {
        var sortingSettings = sortingSettingsSelector.GetSortingSettings();

        return sortingSettings.IsAscending
            ? queryable.OrderBy(sortingSettings.SortingSettings)
            : queryable.OrderByDescending(sortingSettings.SortingSettings);
    }
    
    public static IQueryable<TEntity> GetQueryWithAppliedPagination<TEntity, TModel>(
        this IQueryable<TEntity> queryable,
        IQueryPaginator queryPaginator,
        IFilteringRequestParameters<TModel> filteringRequestParameters)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid> =>
        queryPaginator.ExecutePagination(
            queryable,
            filteringRequestParameters);
    
    public static IQueryable<TEntity> GetQueryWithAppliedTrackingSettings<TEntity>(
        this IQueryable<TEntity> queryable, bool isTracked)
        where TEntity : class, IIdentifiable<Guid> =>
        isTracked
            ? queryable.AsTracking()
            : queryable.AsNoTracking();
}
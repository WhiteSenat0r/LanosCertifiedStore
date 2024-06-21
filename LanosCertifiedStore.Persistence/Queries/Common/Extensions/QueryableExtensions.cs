using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<TEntity> GetQueryWithAppliedFilters<TModel, TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TModel> filteringRequestParameters,
        IQueryFilteringCriteriaSelector<TModel,TEntity> filteringCriteriaSelector)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid> =>
        queryable.Where(filteringCriteriaSelector.GetCriteria(filteringRequestParameters));
    
    public static IQueryable<TEntity> GetQueryWithAppliedSelectionProfile<TModel, TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TModel> filteringRequestParameters,
        IQueryProjectionProfileSelector<TModel, TEntity> projectionProfileSelector)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid> =>
        queryable.Select(projectionProfileSelector.GetProjectionProfile(filteringRequestParameters));

    public static IQueryable<TEntity> GetQueryWithAppliedSortingSettings<TModel, TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TModel> filteringRequestParameters,
        IQuerySortingSettingsSelector<TModel, TEntity> sortingSettingsSelector)
        where TEntity : class, IIdentifiable<Guid>
        where TModel : class, IIdentifiable<Guid>
    {
        var sortingSettings = sortingSettingsSelector.GetSortingSettings(filteringRequestParameters);

        return sortingSettings.IsAscending
            ? queryable.OrderBy(sortingSettings.SortingSettings)
            : queryable.OrderByDescending(sortingSettings.SortingSettings);
    }
    
    public static IQueryable<TEntity> GetQueryWithAppliedPagination<TModel, TEntity>(
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
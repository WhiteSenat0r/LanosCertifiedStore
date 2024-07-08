using Application.Contracts.Common;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Extensions;

internal static class QueryableExtensions
{
    public static IQueryable<TEntity> GetQueryWithAppliedFilters<TEntity>(
        this IQueryable<TEntity> queryable,
        IFilteringRequestParameters<TEntity> filteringRequestParameters,
        IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
        where TEntity : class, IIdentifiable<Guid>
    {
        return queryable.Where(filteringCriteriaSelector.GetCriteria(filteringRequestParameters));
    }

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
        where TEntity : class, IIdentifiable<Guid>
    {
        return queryPaginator.ExecutePagination(queryable, filteringRequestParameters);
    }
}
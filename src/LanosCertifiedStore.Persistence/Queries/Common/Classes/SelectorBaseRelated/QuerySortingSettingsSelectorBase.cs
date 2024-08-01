using System.Linq.Expressions;
using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes.SelectorBaseRelated;

internal abstract class QuerySortingSettingsSelectorBase<TEntity> :
    IQuerySortingSettingsSelector<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    private const string AscendingSuffix = "-asc";
    private const string DescendingSuffix = "-desc";

    public (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null)
    {
        var settings = GetMappedSortingExpressions();
        var sortingExpression = GetSortingExpression(filteringRequestParameters, settings);

        if (ContainsSortingSuffix(filteringRequestParameters, AscendingSuffix))
        {
            return (true, sortingExpression);
        }

        return ContainsSortingSuffix(filteringRequestParameters, DescendingSuffix)
            ? (false, sortingExpression)
            : (true, sortingExpression);
    }

    private protected abstract IReadOnlyDictionary<string, Expression<Func<TEntity, object>>>
        GetMappedSortingExpressions();

    private Expression<Func<TEntity, object>> GetSortingExpression(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters,
        IReadOnlyDictionary<string, Expression<Func<TEntity, object>>> settings)
    {
        if (filteringRequestParameters is null ||
            string.IsNullOrEmpty(filteringRequestParameters.SortingType) ||
            string.IsNullOrWhiteSpace(filteringRequestParameters.SortingType))
        {
            return settings[string.Empty];
        }

        return !settings.TryGetValue(filteringRequestParameters.SortingType.ToLower(), out var expression)
            ? settings[string.Empty]
            : expression;
    }

    private bool ContainsSortingSuffix(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters,
        string suffix) =>
        filteringRequestParameters is not null &&
        (!string.IsNullOrEmpty(filteringRequestParameters.SortingType) ||
         !string.IsNullOrWhiteSpace(filteringRequestParameters.SortingType)) &&
        filteringRequestParameters.SortingType.ToLower().Contains(
            suffix, StringComparison.CurrentCultureIgnoreCase);
}
using System.Linq.Expressions;
using Application.Contracts.RepositoryRelated.Common;
using Domain.Contracts.Common;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.Common.Classes.QueryRelated;

internal abstract class QuerySortingSettingsSelectorBase<TModel, TEntity> : 
    IQuerySortingSettingsSelector<TModel, TEntity>
    where TModel : class, IIdentifiable<Guid>
    where TEntity : class, IIdentifiable<Guid>
{
    private const string AscendingSuffix = "-asc";
    private const string DescendingSuffix = "-desc";
    
    public (bool IsAscending, Expression<Func<TEntity, object>> SortingSettings) GetSortingSettings(
        IFilteringRequestParameters<TModel>? filteringRequestParameters = null)
    {
        var settings = GetMappedSortingExpressions();
        var sortingExpression = GetSortingExpression(filteringRequestParameters, settings);
        
        if (ContainsSortingSuffix(filteringRequestParameters, AscendingSuffix))
            return (true, sortingExpression);
        
        return ContainsSortingSuffix(filteringRequestParameters, DescendingSuffix) 
            ? (false, sortingExpression) 
            : (true, sortingExpression);
    }

    private protected abstract IReadOnlyDictionary<string, Expression<Func<TEntity, object>>> 
        GetMappedSortingExpressions();
    
    private Expression<Func<TEntity, object>> GetSortingExpression(
        IFilteringRequestParameters<TModel>? filteringRequestParameters,
        IReadOnlyDictionary<string, Expression<Func<TEntity, object>>> settings)
    {
        if (filteringRequestParameters is null ||
            string.IsNullOrEmpty(filteringRequestParameters.SortingType) ||
            string.IsNullOrWhiteSpace(filteringRequestParameters.SortingType))
            return settings[string.Empty];
        
        return !settings.TryGetValue(filteringRequestParameters.SortingType.ToLower(), out var expression) 
            ? settings[string.Empty] 
            : expression;
    }

    private bool ContainsSortingSuffix(
        IFilteringRequestParameters<TModel>? filteringRequestParameters,
        string suffix) =>
        filteringRequestParameters is not null &&
        (!string.IsNullOrEmpty(filteringRequestParameters.SortingType) ||
         !string.IsNullOrWhiteSpace(filteringRequestParameters.SortingType)) &&
        filteringRequestParameters.SortingType.ToLower().Contains(
            suffix, StringComparison.CurrentCultureIgnoreCase);
}
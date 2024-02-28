using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryEvaluation.Common;

namespace Persistence.QueryEvaluation;

internal abstract class BaseQueryEvaluator<TSelectionProfile, TEntity, TDataModel>(
    BaseSelectionProfiles<TSelectionProfile, TEntity, TDataModel> selectionProfiles,
    IFilteringRequestParameters<TEntity>? filteringRequestParameters,
    DbSet<TDataModel> dataModels,
    BaseFilteringCriteria<TEntity, TDataModel> filteringCriteria)
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
{
    public IQueryable<TDataModel> GetAllEntitiesQueryable() => 
        filteringRequestParameters is null ? GetRegularQueryable() : GetFilteredQueryable();
    
    public IQueryable<TDataModel> GetSingleEntityQueryable(Guid id) => GetRegularQueryable(id);
    
    public IQueryable<TDataModel> GetRelevantCountQueryable() => 
        filteringRequestParameters is null ? GetRegularCountQueryable() : GetFilterCountQueryable();

    private IQueryable<TDataModel> GetRegularCountQueryable() => dataModels.AsQueryable();

    private IQueryable<TDataModel> GetFilterCountQueryable()
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAppliedFilters(returnedQuery);

        return returnedQuery;
    }

    private protected abstract BaseSortingSettings<TDataModel> GetQuerySortingSettings();
    
    private IQueryable<TDataModel> GetQueryWithAppliedFilters(
        IQueryable<TDataModel> returnedQuery) =>
        returnedQuery.Where(filteringCriteria.GetCriteria(filteringRequestParameters));
    
    private IQueryable<TDataModel> GetRegularQueryable()
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAddedSelects(returnedQuery);

        return returnedQuery;
    }
    
    private IQueryable<TDataModel> GetRegularQueryable(Guid id)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = returnedQuery.Where(model => model.Id.Equals(id));
        returnedQuery = GetQueryWithAddedSelects(returnedQuery);

        return returnedQuery;
    }

    private IQueryable<TDataModel> GetFilteredQueryable()
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAppliedFilters(returnedQuery);
        returnedQuery = GetQueryWithAddedSelects(returnedQuery);

        var sortingSettings = GetQuerySortingSettings();

        if (IsOrderedByAscending(sortingSettings))
            returnedQuery = returnedQuery.OrderBy(sortingSettings.OrderByAscendingExpression!);
        else if (IsOrderedByDescending(sortingSettings))
            returnedQuery = returnedQuery.OrderByDescending(sortingSettings.OrderByDescendingExpression!);

        returnedQuery = returnedQuery
            .Skip(filteringRequestParameters!.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take(filteringRequestParameters!.ItemQuantity);
        
        return returnedQuery;
    }

    private IQueryable<TDataModel> GetQueryWithAddedSelects(IQueryable<TDataModel> returnedQuery) =>
        (selectionProfiles.GetSuitableSelectionProfileQueryable(returnedQuery, filteringRequestParameters!)
            as IQueryable<TDataModel>)!;

    private bool IsOrderedByDescending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByDescendingExpression is not null 
        && sortingSettings.OrderByAscendingExpression is null;

    private bool IsOrderedByAscending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByAscendingExpression is not null 
        && sortingSettings.OrderByDescendingExpression is null;
}
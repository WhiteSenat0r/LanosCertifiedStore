using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryEvaluation.Common;

namespace Persistence.QueryEvaluation;

internal abstract class BaseQueryEvaluator<TSelectionProfile, TEntity, TDataModel>(
    BaseSelectionProfiles<TSelectionProfile, TEntity, TDataModel> selectionProfiles,
    BaseFilteringCriteria<TEntity, TDataModel> filteringCriteria)
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
{
    public IQueryable<TDataModel> GetAllEntitiesQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!) => 
        filteringRequestParameters is null 
            ? GetRegularQueryable(dataModels, filteringRequestParameters) 
            : GetFilteredQueryable(dataModels, filteringRequestParameters);
    
    public IQueryable<TDataModel> GetSingleEntityQueryable(
        Guid entityId,
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!) =>
        GetRegularQueryable(entityId, dataModels, filteringRequestParameters);
    
    public IQueryable<TDataModel> GetRelevantCountQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters = null!) => 
        filteringRequestParameters is null 
            ? GetRegularCountQueryable(dataModels) 
            : GetFilterCountQueryable(dataModels, filteringRequestParameters);

    private IQueryable<TDataModel> GetRegularCountQueryable(DbSet<TDataModel> dataModels) =>
        dataModels.AsQueryable();

    private IQueryable<TDataModel> GetFilterCountQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAppliedFilters(filteringRequestParameters, returnedQuery);

        return returnedQuery;
    }

    private protected abstract BaseSortingSettings<TDataModel> GetQuerySortingSettings(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters);
    
    private IQueryable<TDataModel> GetQueryWithAppliedFilters(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters,
        IQueryable<TDataModel> returnedQuery) =>
        returnedQuery.Where(filteringCriteria.GetCriteria(filteringRequestParameters));
    
    private IQueryable<TDataModel> GetRegularQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAddedSelects(returnedQuery, filteringRequestParameters);

        return returnedQuery;
    }
    
    private IQueryable<TDataModel> GetRegularQueryable(Guid id,
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = returnedQuery.Where(model => model.Id.Equals(id));
        returnedQuery = GetQueryWithAddedSelects(returnedQuery, filteringRequestParameters);

        return returnedQuery;
    }

    private IQueryable<TDataModel> GetFilteredQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAppliedFilters(filteringRequestParameters, returnedQuery);
        returnedQuery = GetQueryWithAddedSelects(returnedQuery, filteringRequestParameters);

        var sortingSettings = GetQuerySortingSettings(filteringRequestParameters);

        if (IsOrderedByAscending(sortingSettings))
            returnedQuery = returnedQuery.OrderBy(sortingSettings.OrderByAscendingExpression!);
        else if (IsOrderedByDescending(sortingSettings))
            returnedQuery = returnedQuery.OrderByDescending(sortingSettings.OrderByDescendingExpression!);

        returnedQuery = returnedQuery
            .Skip(filteringRequestParameters!.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take(filteringRequestParameters!.ItemQuantity);
        
        return returnedQuery;
    }

    private IQueryable<TDataModel> GetQueryWithAddedSelects(IQueryable<TDataModel> returnedQuery,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters) =>
        (selectionProfiles.GetSuitableSelectionProfileQueryable(returnedQuery, filteringRequestParameters!)
            as IQueryable<TDataModel>)!;

    private bool IsOrderedByDescending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByDescendingExpression is not null 
        && sortingSettings.OrderByAscendingExpression is null;

    private bool IsOrderedByAscending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByAscendingExpression is not null 
        && sortingSettings.OrderByDescendingExpression is null;
}
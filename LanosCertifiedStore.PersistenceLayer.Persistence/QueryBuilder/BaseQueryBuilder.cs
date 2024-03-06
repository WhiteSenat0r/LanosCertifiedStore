using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.QueryBuilder.Common;

namespace Persistence.QueryBuilder;

internal abstract class BaseQueryBuilder<TSelectionProfile, TEntity, TDataModel, TParamsType>(
    BaseSelectionProfiles<TSelectionProfile, TEntity, TDataModel> selectionProfiles,
    BaseFilteringCriteria<TEntity, TDataModel, TParamsType> filteringCriteria)
    where TSelectionProfile : struct, Enum
    where TEntity : IIdentifiable<Guid>
    where TDataModel : class, IIdentifiable<Guid>
    where TParamsType : class, IFilteringRequestParameters<TEntity>
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
    
    private protected IQueryable<TDataModel> GetQueryWithAppliedFilters(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters,
        IQueryable<TDataModel> returnedQuery) =>
        returnedQuery.Where(filteringCriteria.GetCriteria(filteringRequestParameters));
    
    private IQueryable<TDataModel> GetRegularQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = GetQueryWithAddedSelects(filteringRequestParameters, returnedQuery);

        return returnedQuery;
    }
    
    private IQueryable<TDataModel> GetRegularQueryable(Guid id,
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();

        returnedQuery = returnedQuery.Where(model => model.Id.Equals(id));
        returnedQuery = GetQueryWithAddedSelects(filteringRequestParameters, returnedQuery);

        return returnedQuery;
    }

    private IQueryable<TDataModel> GetFilteredQueryable(
        DbSet<TDataModel> dataModels,
        IFilteringRequestParameters<TEntity>? filteringRequestParameters)
    {
        var returnedQuery = dataModels.AsQueryable();
        
        returnedQuery = GetQueryWithAppliedFilters(filteringRequestParameters, returnedQuery);
        returnedQuery = GetSortedQuery(filteringRequestParameters, returnedQuery);
        returnedQuery = GetQueryWithAddedSelects(filteringRequestParameters, returnedQuery);
        returnedQuery = GetPaginatedQuery(filteringRequestParameters, returnedQuery);
        
        return returnedQuery;
    }

    private IQueryable<TDataModel> GetPaginatedQuery(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters, IQueryable<TDataModel> returnedQuery)
    {
        returnedQuery = returnedQuery
            .Skip(filteringRequestParameters!.ItemQuantity * (filteringRequestParameters.PageIndex - 1))
            .Take(filteringRequestParameters!.ItemQuantity);
        
        return returnedQuery;
    }

    private IQueryable<TDataModel> GetSortedQuery(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters, IQueryable<TDataModel> returnedQuery)
    {
        var sortingSettings = GetQuerySortingSettings(filteringRequestParameters);
        
        if (IsOrderedByAscending(sortingSettings))
            returnedQuery = returnedQuery.OrderBy(sortingSettings.OrderByAscendingExpression!);
        else if (IsOrderedByDescending(sortingSettings))
            returnedQuery = returnedQuery.OrderByDescending(sortingSettings.OrderByDescendingExpression!);
        
        return returnedQuery;
    }

    private protected IQueryable<TDataModel> GetQueryWithAddedSelects(
        IFilteringRequestParameters<TEntity>? filteringRequestParameters,
        IQueryable<TDataModel> returnedQuery) =>
        selectionProfiles.GetSuitableSelectionProfileQueryable(returnedQuery, filteringRequestParameters!)!;

    private bool IsOrderedByDescending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByDescendingExpression is not null 
        && sortingSettings.OrderByAscendingExpression is null;

    private bool IsOrderedByAscending(BaseSortingSettings<TDataModel> sortingSettings) =>
        sortingSettings.OrderByAscendingExpression is not null 
        && sortingSettings.OrderByDescendingExpression is null;
}
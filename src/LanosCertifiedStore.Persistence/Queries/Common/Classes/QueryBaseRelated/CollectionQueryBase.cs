using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;
using LanosCertifiedStore.Persistence.Queries.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class CollectionQueryBase<TEntity, TDto>
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class
{
    public abstract Task<IReadOnlyCollection<TDto>> Execute<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull;

    private protected IQueryable<TEntity> GetPaginatedQueryable<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        IQueryable<TEntity> queryable,
        IQueryPaginator queryPaginator) 
        where TRequestResult : notnull
    {
        return queryable.GetQueryWithAppliedPagination(queryPaginator, queryRequest.FilteringParameters);
    }

    private protected IQueryable<TEntity> GetSortedQueryable<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        IQueryable<TEntity> queryable,
        IQuerySortingSettingsSelector<TEntity> sortingSettingsSelector) 
        where TRequestResult : notnull
    {
        return queryable.GetQueryWithAppliedSortingSettings(
            queryRequest.FilteringParameters, sortingSettingsSelector);
    }

    private protected IQueryable<TEntity> GetFilteredQueryable<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        IQueryable<TEntity> queryable,
        IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector)
        where TRequestResult : notnull
    {
        return queryable.GetQueryWithAppliedFilters(
            queryRequest.FilteringParameters, filteringCriteriaSelector!);
    }

    private protected IQueryable<TEntity> GetDatabaseQueryable(ApplicationDatabaseContext context)
    {
        var dataSet = context.Set<TEntity>();

        return dataSet.AsQueryable();
    }

    private protected async Task<IReadOnlyCollection<TDto>> GetQueryResult(
        IQueryable<TEntity> queryable,
        IMapper mapper,
        CancellationToken cancellationToken)
    {
        var items = await queryable
            .AsNoTracking()
            .ProjectTo<TDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return items;
    }
}
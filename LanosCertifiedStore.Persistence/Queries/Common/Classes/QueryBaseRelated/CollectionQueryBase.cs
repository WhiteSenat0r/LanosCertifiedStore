using Application.Contracts.RequestRelated.QueryRelated;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Contracts.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Contracts;
using Persistence.Queries.Common.Extensions;

namespace Persistence.Queries.Common.Classes.QueryBaseRelated;

public abstract class CollectionQueryBase<TEntity, TDto>(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<TEntity> sortingSettingsSelector,
    IQueryFilteringCriteriaSelector<TEntity> filteringCriteriaSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class
{
    public async Task<IReadOnlyCollection<TDto>> Execute<TRequestResult>(
        IQueryRequest<TEntity, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
        where TRequestResult : notnull
    {
        var queryable = GetDatabaseQueryable();

        queryable = queryable.GetQueryWithAppliedFilters(queryRequest.FilteringParameters, filteringCriteriaSelector);
        queryable = queryable.GetQueryWithAppliedSortingSettings(
            queryRequest.FilteringParameters, sortingSettingsSelector);

        queryable = queryable.GetQueryWithAppliedPagination(queryPaginator, queryRequest.FilteringParameters);

        var executionResult = await GetQueryResult(queryable, cancellationToken);

        return executionResult;
    }

    private IQueryable<TEntity> GetDatabaseQueryable()
    {
        var dataSet = context.Set<TEntity>();

        return dataSet.AsQueryable();
    }

    private async Task<IReadOnlyCollection<TDto>> GetQueryResult(
        IQueryable<TEntity> queryable,
        CancellationToken cancellationToken)
    {
        var items = queryable
            .AsNoTracking()
            .ProjectTo<TDto>(mapper.ConfigurationProvider);
        // .ToListAsync(cancellationToken);

        return await items.ToListAsync(cancellationToken);
    }
}
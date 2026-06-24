using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated.Common;

public abstract class CollectionVehiclesQueryBase<TDto>(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<Vehicle> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<Vehicle, TDto>(context, mapper)
    where TDto : class
{
    public sealed override async Task<IEnumerable<TDto>> Execute(
        IQueryRequest<Vehicle> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);
        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}

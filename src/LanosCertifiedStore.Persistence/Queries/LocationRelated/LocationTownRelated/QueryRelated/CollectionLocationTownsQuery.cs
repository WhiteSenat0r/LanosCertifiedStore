using AutoMapper;
using LanosCertifiedStore.Application.LocationTowns.Dtos;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

public sealed class CollectionLocationTownsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleLocationTown> filteringCriteriaSelector,
    IQuerySortingSettingsSelector<VehicleLocationTown> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleLocationTown, LocationTownDto>
{
    public override async Task<IReadOnlyCollection<LocationTownDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleLocationTown, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);
        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
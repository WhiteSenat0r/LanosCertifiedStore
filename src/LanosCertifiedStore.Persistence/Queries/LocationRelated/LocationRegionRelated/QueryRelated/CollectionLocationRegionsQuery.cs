using AutoMapper;
using LanosCertifiedStore.Application.LocationRegions.Dtos;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;

public sealed class CollectionLocationRegionsQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleLocationRegion> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleLocationRegion, LocationRegionDto>
{
    public override async Task<IReadOnlyCollection<LocationRegionDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleLocationRegion, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
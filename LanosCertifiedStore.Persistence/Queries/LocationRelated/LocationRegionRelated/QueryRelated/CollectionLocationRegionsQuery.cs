using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.LocationDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.LocationRelated.LocationRegionRelated.QueryRelated;

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
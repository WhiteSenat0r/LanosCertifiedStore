using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.LocationDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

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
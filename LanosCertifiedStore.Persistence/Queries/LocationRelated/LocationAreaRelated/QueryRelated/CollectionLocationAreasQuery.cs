using Application.Contracts.RequestParametersRelated;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.LocationDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.LocationRelated.LocationAreaRelated.QueryRelated;

public sealed class CollectionLocationAreasQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleLocationArea> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper
) : CollectionQueryBase<VehicleLocationArea, LocationAreaDto>
{
    public override async Task<IReadOnlyCollection<LocationAreaDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleLocationArea, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var requestParams = queryRequest.FilteringParameters as ILocationAreaFilteringRequestParameters;
        var queryable = GetDatabaseQueryable(context);

        queryable = queryable.Where(area => area.LocationRegionId == requestParams!.LocationRegionId);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
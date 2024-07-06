using Application.Contracts.RequestParametersRelated;
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.LocationRelated.LocationAreaRelated.QueryRelated;

public sealed class CountLocationAreasQuery(
    ApplicationDatabaseContext context) : CountQueryBase<VehicleLocationArea>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleLocationArea, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var requestParams = queryRequest.FilteringParameters as ILocationAreaFilteringRequestParameters;
        var totalQueryable = GetDatabaseQueryable(context);

        var filteredQueryable = totalQueryable.Where(area => area.LocationRegionId == requestParams!.LocationRegionId);

        var executionResult = await GetQueryResult(totalQueryable, cancellationToken, filteredQueryable);

        return executionResult;
    }
}
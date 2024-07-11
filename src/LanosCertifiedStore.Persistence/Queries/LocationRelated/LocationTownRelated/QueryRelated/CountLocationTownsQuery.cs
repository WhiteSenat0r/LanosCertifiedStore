using Application.Shared.DtosRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated.LocationRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

public sealed class CountLocationTownsQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<VehicleLocationTown> filteringCriteriaSelector) : CountQueryBase<VehicleLocationTown>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleLocationTown, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        var filteredQueryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);
        
        var executionResult = await GetQueryResult(queryable, cancellationToken, filteredQueryable);

        return executionResult;
    }
}
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.LocationRelated.LocationTownRelated.QueryRelated;

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
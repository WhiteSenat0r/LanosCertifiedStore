using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class CountVehiclesQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector) : CountQueryBase<Vehicle>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<Vehicle, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        var filteredQueryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);

        var vehiclesCount = await GetQueryResult(queryable, cancellationToken, filteredQueryable);

        return vehiclesCount;
    }
}
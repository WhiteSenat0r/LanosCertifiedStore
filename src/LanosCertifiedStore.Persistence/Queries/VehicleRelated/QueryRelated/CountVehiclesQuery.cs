using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class CountVehiclesQuery(
    ApplicationDatabaseContext context,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector) : CountQueryBase<Vehicle>(context)
{
    public override async Task<ItemsCountDto> Execute(
        IQueryRequest<Vehicle> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);

        var count = await GetItemsCount(queryable, cancellationToken);

        return new ItemsCountDto { Count = count };
    }
}

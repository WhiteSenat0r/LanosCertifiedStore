using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class CollectionVehiclesQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<Vehicle> sortingSettingsSelector,
    IMapper mapper,
    IQueryFilteringCriteriaSelector<Vehicle> filteringCriteriaSelector,
    IQueryPaginator queryPaginator) : CollectionQueryBase<Vehicle, VehicleDto>
{
    public override async Task<IReadOnlyCollection<VehicleDto>> Execute<TRequestResult>(
        IQueryRequest<Vehicle, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);
        queryable = GetFilteredQueryable(queryRequest, queryable, filteringCriteriaSelector);
        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var vehicles = await GetQueryResult(queryable, mapper, cancellationToken);

        return vehicles;
    }
}
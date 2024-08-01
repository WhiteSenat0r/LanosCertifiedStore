using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleEngineTypes;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

public sealed class CollectionVehicleEngineTypesQuery(
    IQuerySortingSettingsSelector<VehicleEngineType> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    ApplicationDatabaseContext context,
    IMapper mapper)
    : CollectionQueryBase<VehicleEngineType, VehicleEngineTypeDto>
{
    public override async Task<IReadOnlyCollection<VehicleEngineTypeDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleEngineType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
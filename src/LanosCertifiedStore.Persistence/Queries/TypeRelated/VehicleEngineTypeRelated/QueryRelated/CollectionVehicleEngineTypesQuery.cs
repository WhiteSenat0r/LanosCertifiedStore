using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleEngineTypes;
using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.TypeRelated.VehicleEngineTypeRelated.QueryRelated;

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
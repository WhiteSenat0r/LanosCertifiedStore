using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleColors;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleColorRelated.QueryRelated;

public sealed class CollectionVehicleColorsQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleColor> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleColor, VehicleColorDto>
{
    public override async Task<IReadOnlyCollection<VehicleColorDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleColor, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
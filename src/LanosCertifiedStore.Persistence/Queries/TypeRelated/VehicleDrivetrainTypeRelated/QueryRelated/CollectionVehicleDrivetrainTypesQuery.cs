using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleDrivetrainTypes;
using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

public sealed class CollectionVehicleDrivetrainTypesQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleDrivetrainType> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper)
    : CollectionQueryBase<VehicleDrivetrainType, VehicleDrivetrainTypeDto>
{
    public override async Task<IReadOnlyCollection<VehicleDrivetrainTypeDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleDrivetrainType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var queryResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return queryResult;
    }
}
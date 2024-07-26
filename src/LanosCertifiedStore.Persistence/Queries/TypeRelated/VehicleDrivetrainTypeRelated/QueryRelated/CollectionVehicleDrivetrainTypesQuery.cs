using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleDrivetrainTypes;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

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
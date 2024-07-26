using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleTransmissionTypes;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

public sealed class CollectionVehicleTransmissionTypesQuery(
    IQuerySortingSettingsSelector<VehicleTransmissionType> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    ApplicationDatabaseContext context,
    IMapper mapper)
    : CollectionQueryBase<VehicleTransmissionType, VehicleTransmissionTypeDto>
{
    public override async Task<IReadOnlyCollection<VehicleTransmissionTypeDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleTransmissionType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
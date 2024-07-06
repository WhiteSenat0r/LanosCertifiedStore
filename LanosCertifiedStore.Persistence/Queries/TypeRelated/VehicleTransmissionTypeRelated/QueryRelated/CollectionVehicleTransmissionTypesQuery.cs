using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.TypeRelated.VehicleTransmissionTypeRelated.QueryRelated;

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
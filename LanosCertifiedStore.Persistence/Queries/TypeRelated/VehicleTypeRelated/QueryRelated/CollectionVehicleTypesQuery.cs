using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.TypeDtos;
using AutoMapper;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;

public sealed class CollectionVehicleTypesQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleType> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleType, VehicleTypeDto>
{
    public override async Task<IReadOnlyCollection<VehicleTypeDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
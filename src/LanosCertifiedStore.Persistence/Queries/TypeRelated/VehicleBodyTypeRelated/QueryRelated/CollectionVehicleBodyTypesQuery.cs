using AutoMapper;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.VehicleBodyTypes;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using LanosCertifiedStore.Persistence.Queries.Common.Contracts;

namespace LanosCertifiedStore.Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;

public sealed class CollectionVehicleBodyTypesQuery(
    IQuerySortingSettingsSelector<VehicleBodyType> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    ApplicationDatabaseContext context,
    IMapper mapper)
    : CollectionQueryBase<VehicleBodyType, VehicleBodyTypeDto>
{
    public override async Task<IReadOnlyCollection<VehicleBodyTypeDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleBodyType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
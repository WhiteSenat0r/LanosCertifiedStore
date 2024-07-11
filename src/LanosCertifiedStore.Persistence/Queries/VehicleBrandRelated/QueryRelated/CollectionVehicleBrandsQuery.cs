using Application.Shared.RequestRelated.QueryRelated;
using Application.VehicleBrands.Dtos;
using AutoMapper;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class CollectionVehicleBrandsQuery(
    ApplicationDatabaseContext context,
    IQuerySortingSettingsSelector<VehicleBrand> sortingSettingsSelector,
    IQueryPaginator queryPaginator,
    IMapper mapper) : CollectionQueryBase<VehicleBrand, VehicleBrandDto>
{
    public override async Task<IReadOnlyCollection<VehicleBrandDto>> Execute<TRequestResult>(
        IQueryRequest<VehicleBrand, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        queryable = GetSortedQueryable(queryRequest, queryable, sortingSettingsSelector);

        queryable = GetPaginatedQueryable(queryRequest, queryable, queryPaginator);

        var executionResult = await GetQueryResult(queryable, mapper, cancellationToken);

        return executionResult;
    }
}
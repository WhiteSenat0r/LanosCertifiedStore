using Application.Shared.DtosRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.VehicleBrandRelated.QueryRelated;

public sealed class CountVehicleBrandsQuery(ApplicationDatabaseContext context) : CountQueryBase<VehicleBrand>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleBrand, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var totalQueryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(totalQueryable, cancellationToken);

        return executionResult;
    }
}
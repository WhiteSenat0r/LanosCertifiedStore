using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.VehicleColorRelated.QueryRelated;

public sealed class CountVehicleColorsQuery(
    ApplicationDatabaseContext context
) : CountQueryBase<VehicleColor>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleColor, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var totalQueryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(totalQueryable, cancellationToken);

        return executionResult;
    }
}
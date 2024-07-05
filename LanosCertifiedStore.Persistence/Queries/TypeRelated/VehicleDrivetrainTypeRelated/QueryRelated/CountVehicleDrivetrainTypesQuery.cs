using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.TypeRelated.VehicleDrivetrainTypeRelated.QueryRelated;

public sealed class CountVehicleDrivetrainTypesQuery(
    ApplicationDatabaseContext context) : CountQueryBase<VehicleDrivetrainType>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleDrivetrainType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(queryable, cancellationToken);

        return executionResult;
    }
}
using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.TypeRelated.VehicleTypeRelated.QueryRelated;

public sealed class CountVehicleTypesQuery(ApplicationDatabaseContext context) : CountQueryBase<VehicleType>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var totalQueryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(totalQueryable, cancellationToken);

        return executionResult;
    }
}
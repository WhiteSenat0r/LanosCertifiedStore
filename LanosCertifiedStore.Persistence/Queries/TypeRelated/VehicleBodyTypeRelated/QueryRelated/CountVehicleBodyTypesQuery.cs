using Application.Contracts.RequestRelated.QueryRelated;
using Application.Dtos.Common;
using Domain.Entities.VehicleRelated.TypeRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.TypeRelated.VehicleBodyTypeRelated.QueryRelated;

public sealed class CountVehicleBodyTypesQuery(
    ApplicationDatabaseContext context) : CountQueryBase<VehicleBodyType>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleBodyType, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var queryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(queryable, cancellationToken);

        return executionResult;
    }
}
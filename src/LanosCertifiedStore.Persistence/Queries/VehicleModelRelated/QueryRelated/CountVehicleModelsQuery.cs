using Application.Shared.DtosRelated;
using Application.Shared.RequestRelated.QueryRelated;
using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace Persistence.Queries.VehicleModelRelated.QueryRelated;

public sealed class CountVehicleModelsQuery(ApplicationDatabaseContext context) : CountQueryBase<VehicleModel>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<VehicleModel, TRequestResult> queryRequest, CancellationToken cancellationToken)
    {
        var totalQueryable = GetDatabaseQueryable(context);

        var executionResult = await GetQueryResult(totalQueryable, cancellationToken);

        return executionResult;
    }
}
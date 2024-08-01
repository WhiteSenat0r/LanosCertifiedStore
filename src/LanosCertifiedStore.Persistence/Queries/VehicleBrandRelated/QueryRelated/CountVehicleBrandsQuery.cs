using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace LanosCertifiedStore.Persistence.Queries.VehicleBrandRelated.QueryRelated;

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
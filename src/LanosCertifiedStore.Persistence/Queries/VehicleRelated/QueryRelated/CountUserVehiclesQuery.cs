using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class CountUserVehiclesQuery(ApplicationDatabaseContext context) : CountQueryBase<Vehicle>
{
    public override async Task<ItemsCountDto> Execute<TRequestResult>(
        IQueryRequest<Vehicle, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var userId = (queryRequest.FilteringParameters as IVehicleFilteringRequestParameters)!.UserId;

        var queryable = context.Set<Vehicle>().AsQueryable();

        queryable = queryable.Where(v => v.OwnerId.Equals(userId));
        queryable = queryable
            .Skip((int)queryRequest.FilteringParameters.ItemQuantity * (queryRequest.FilteringParameters.PageIndex - 1))
            .Take((int)queryRequest.FilteringParameters.ItemQuantity);

        var count = await queryable.AsNoTracking().CountAsync(cancellationToken);

        return new ItemsCountDto(count, count);
    }
}
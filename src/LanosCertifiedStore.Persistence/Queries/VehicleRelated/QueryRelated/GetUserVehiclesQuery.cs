using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class GetUserVehiclesQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) : CollectionQueryBase<Vehicle, VehicleDto>
{
    public override async Task<IReadOnlyCollection<VehicleDto>> Execute<TRequestResult>(
        IQueryRequest<Vehicle, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var userId = (queryRequest.FilteringParameters as IVehicleFilteringRequestParameters)!.UserId;

        var queryable = context.Set<Vehicle>().AsQueryable();

        queryable = queryable.Where(v => v.OwnerId.Equals(userId));
        queryable = queryable
            .Skip((int)queryRequest.FilteringParameters.ItemQuantity * (queryRequest.FilteringParameters.PageIndex - 1))
            .Take((int)queryRequest.FilteringParameters.ItemQuantity);

        return await queryable
            .AsNoTracking()
            .ProjectTo<VehicleDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
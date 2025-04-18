using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.UserRelated;

public sealed class GetUserWishlistQuery(
    ApplicationDatabaseContext context,
    IMapper mapper) : CollectionQueryBase<UserWishlist, VehicleDto>
{
    public override async Task<IReadOnlyCollection<VehicleDto>> Execute<TRequestResult>(
        IQueryRequest<UserWishlist, TRequestResult> queryRequest,
        CancellationToken cancellationToken)
    {
        var userId = (queryRequest.FilteringParameters as IUserWishlistFilteringRequestParameters)!.UserId;
        var wishlist = await context.Set<UserWishlist>()
            .SingleAsync(l => l.UserId.Equals(userId), cancellationToken);

        var queryable = context.Set<Vehicle>().AsQueryable();

        queryable = queryable.Where(v => v.Wishlists.Any(l => l.Id.Equals(wishlist.Id)));
        queryable = queryable
            .Skip((int)queryRequest.FilteringParameters.ItemQuantity * (queryRequest.FilteringParameters.PageIndex - 1))
            .Take((int)queryRequest.FilteringParameters.ItemQuantity);

        return await queryable
            .AsNoTracking()
            .ProjectTo<VehicleDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
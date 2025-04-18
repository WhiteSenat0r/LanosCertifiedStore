using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class VehicleWishlistStatusesQuery(ApplicationDatabaseContext context)
{
    public async Task<Dictionary<Guid, bool>> Execute(
        List<Guid> vehicleIds,
        Guid userId,
        CancellationToken cancellationToken)
    {
        var wishlist = await context.Set<UserWishlist>()
            .Include(l => l.Vehicles).AsNoTracking()
            .SingleAsync(l => l.UserId.Equals(userId), cancellationToken);
        
        var wishlistVehicleIds = wishlist.Vehicles.Select(v => v.Id).ToHashSet();

        return vehicleIds.ToDictionary(id => id, id => wishlistVehicleIds.Contains(id));
    }
}
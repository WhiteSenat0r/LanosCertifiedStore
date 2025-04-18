using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class RemoveVehicleFromWishlistCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Guid vehicleId, Guid userId, CancellationToken cancellationToken)
    {
        var wishlist = await context
            .Set<UserWishlist>()
            .Include(l => l.Vehicles)
            .SingleAsync(l => l.UserId == userId, cancellationToken: cancellationToken);

        var vehicle = wishlist.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
        
        if (vehicle is null)
        {
            throw new KeyNotFoundException();
        }
        
        wishlist.Vehicles.Remove(vehicle);
    }
}
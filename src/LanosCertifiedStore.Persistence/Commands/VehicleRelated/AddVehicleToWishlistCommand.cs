using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class AddVehicleToWishlistCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Guid vehicleId, Guid userId, CancellationToken cancellationToken)
    {
        var vehicle = await context
            .Set<Vehicle>()
            .SingleOrDefaultAsync(v => v.Id == vehicleId, cancellationToken: cancellationToken);

        if (vehicle is null)
        {
            throw new KeyNotFoundException();
        }
        
        var wishlist = await context
            .Set<UserWishlist>()
            .SingleAsync(l => l.UserId == userId, cancellationToken: cancellationToken);
        
        wishlist.Vehicles.Add(vehicle);
    }
}
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class AddImagesToVehicleCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Guid vehicleId, List<VehicleImage> images, CancellationToken cancellationToken)
    {
        var mainImageExist = await context
            .Set<VehicleImage>()
            .Where(i => i.VehicleId == vehicleId)
            .AnyAsync(i => i.IsMainImage, cancellationToken);

        if (mainImageExist)
        {
            await context.AddRangeAsync(images, cancellationToken);
            return;
        }

        images[0].IsMainImage = true;
        await context.AddRangeAsync(images, cancellationToken);
    }
}
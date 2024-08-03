using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class CreateVehicleCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await context.AddAsync(vehicle, cancellationToken);
    }
}
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.Persistence.Commands.VehicleBrandRelated;

public sealed class CreateVehicleBrandCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(VehicleBrand addedVehicleBrand, CancellationToken cancellationToken)
    {
        await context.Set<VehicleBrand>().AddAsync(addedVehicleBrand, cancellationToken);
    }
}
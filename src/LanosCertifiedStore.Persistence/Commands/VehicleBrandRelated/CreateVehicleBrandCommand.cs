using Domain.Entities.VehicleRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.VehicleBrandRelated;

public sealed class CreateVehicleBrandCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(VehicleBrand addedVehicleBrand, CancellationToken cancellationToken)
    {
        await context.Set<VehicleBrand>().AddAsync(addedVehicleBrand, cancellationToken);
    }
}
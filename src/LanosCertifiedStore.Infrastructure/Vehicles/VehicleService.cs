using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.VehicleRelated;

namespace LanosCertifiedStore.Infrastructure.Vehicles;

internal sealed class VehicleService(
    CreateVehicleCommand createVehicleCommand,
    SaveChangesCommand saveChangesCommand) : IVehicleService
{
    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await createVehicleCommand.Execute(vehicle, cancellationToken);
        await saveChangesCommand.Execute(cancellationToken);
    }
}
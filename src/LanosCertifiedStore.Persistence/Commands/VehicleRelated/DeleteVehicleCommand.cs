using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class DeleteVehicleCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Guid id, CancellationToken cancellationToken)
    {
        await context
            .Set<Vehicle>()
            .Where(v => v.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}
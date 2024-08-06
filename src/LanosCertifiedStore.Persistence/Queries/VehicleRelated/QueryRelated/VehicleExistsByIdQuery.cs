using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Queries.VehicleRelated.QueryRelated;

public sealed class VehicleExistsByIdQuery(ApplicationDatabaseContext context)
{
    public async Task<bool> Execute(Guid id, CancellationToken cancellationToken)
    {
        return await context
            .Set<Vehicle>()
            .AnyAsync(v => v.Id == id, cancellationToken);
    }
}
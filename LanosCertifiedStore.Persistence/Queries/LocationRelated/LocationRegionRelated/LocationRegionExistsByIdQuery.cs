using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Queries.LocationRelated.LocationRegionRelated;

public sealed class LocationRegionExistsByIdQuery(ApplicationDatabaseContext context)
{
    public async Task<bool> Execute(Guid regionId, CancellationToken cancellationToken)
    {
        return await context.VehicleLocationRegions.AnyAsync(x => x.Id == regionId, cancellationToken);
    }
}
using Application.Contracts.ServicesRelated.LocationRelated;
using Persistence.Queries.LocationRelated.LocationRegionRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.LocationRelated;

internal sealed class LocationRegionService(LocationRegionExistsByIdQuery locationRegionExistsByIdQuery) : ILocationRegionService
{
    public async Task<bool> ExistsById(Guid regionId, CancellationToken cancellationToken)
    {
        return await locationRegionExistsByIdQuery.Execute(regionId, cancellationToken);
    }
}
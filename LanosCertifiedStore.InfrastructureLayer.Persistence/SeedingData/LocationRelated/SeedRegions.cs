using Persistence.Entities.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedRegions
{
    public static List<VehicleLocationRegionEntity> GetRegions(ICollection<string> regionNames) =>
        regionNames.Select(name => new VehicleLocationRegionEntity(name)).ToList();
}
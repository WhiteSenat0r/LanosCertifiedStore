using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedRegions
{
    public static List<VehicleLocationRegion> GetRegions(ICollection<string> regionNames) =>
        regionNames.Select(name => new VehicleLocationRegion(name)).ToList();
}
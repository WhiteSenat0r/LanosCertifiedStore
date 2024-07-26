using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;

namespace LanosCertifiedStore.Persistence.SeedingData.LocationRelated;

internal static class SeedRegions
{
    public static List<VehicleLocationRegion> GetRegions(ICollection<string> regionNames) =>
        regionNames.Select(name => new VehicleLocationRegion(name)).ToList();
}
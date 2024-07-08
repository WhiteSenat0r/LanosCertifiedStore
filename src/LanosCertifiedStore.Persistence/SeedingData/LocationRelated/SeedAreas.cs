using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedAreas
{
    public static List<VehicleLocationArea> GetAreas(
        Dictionary<string, string> areaRegionDictionary,
        ICollection<VehicleLocationRegion> regions) =>
        areaRegionDictionary.Select(
            pair => new VehicleLocationArea(pair.Key)
            {
                LocationRegionId = regions.Single(
                    r => r.Name.Equals(pair.Value)).Id
            }).ToList();
}
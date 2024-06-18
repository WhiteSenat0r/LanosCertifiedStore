using Persistence.Entities.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedAreas
{
    public static List<VehicleLocationAreaEntity> GetAreas(
        Dictionary<string, string> areaRegionDictionary,
        ICollection<VehicleLocationRegionEntity> regions) =>
        areaRegionDictionary.Select(
            pair => new VehicleLocationAreaEntity(pair.Key)
            {
                LocationRegionId = regions.Single(
                    r => r.Name.Equals(pair.Value)).Id
            }).ToList();
}
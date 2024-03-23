using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData;

internal static class SeedAreas
{
    public static List<VehicleLocationAreaDataModel> GetAreas(
        Dictionary<string, string> areaRegionDictionary,
        ICollection<VehicleLocationRegionDataModel> regions) =>
        areaRegionDictionary.Select(
            pair => new VehicleLocationAreaDataModel(pair.Key)
            {
                LocationRegionId = regions.Single(
                    r => r.Name.Equals(pair.Value)).Id
            }).ToList();
}
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedRegions
{
    public static List<VehicleLocationRegionDataModel> GetRegions(ICollection<string> regionNames) =>
        regionNames.Select(name => new VehicleLocationRegionDataModel(name)).ToList();
}
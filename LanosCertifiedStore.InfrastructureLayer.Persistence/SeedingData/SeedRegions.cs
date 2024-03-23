using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData;

internal static class SeedRegions
{
    public static List<VehicleLocationRegionDataModel> GetRegions(ICollection<string> regionNames) =>
        regionNames.Select(name => new VehicleLocationRegionDataModel(name)).ToList();
}
using Persistence.DataModels.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData;

internal static class SeedTowns
{
    public static List<VehicleLocationTownDataModel> GetTowns(
        ICollection<VehicleLocationRegionDataModel> regions,
        ICollection<VehicleLocationAreaDataModel> areas,
        Dictionary<string, Dictionary<string, List<string>>> regionAreaTownDictionary) =>
        regionAreaTownDictionary.SelectMany(
            regionAreaPair => regionAreaPair.Value.SelectMany(
                areaTownPair => areaTownPair.Value.Select(
                    town => new VehicleLocationTownDataModel(
                        town,
                        areas.Single(r => r.Name.Equals(areaTownPair.Key)),
                        regions.Single(r => r.Name.Equals(regionAreaPair.Key)))
                    {
                        LocationRegionId = regions.Single(
                            r => r.Name.Equals(regionAreaPair.Key)).Id,
                        LocationAreaId = areas.Single(
                            r => r.Name.Equals(areaTownPair.Key)).Id,
                    }))).ToList();
}
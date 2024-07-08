using Domain.Entities.VehicleRelated.LocationRelated;

namespace Persistence.SeedingData.LocationRelated;

internal static class SeedTowns
{
    public static List<VehicleLocationTown> GetTowns(
        ICollection<VehicleLocationRegion> regions,
        ICollection<VehicleLocationArea> areas,
        ICollection<VehicleLocationTownType> townTypes,
        Dictionary<string, Dictionary<string, List<KeyValuePair<string, string>>>> regionAreaTownDictionary)
    {
        return regionAreaTownDictionary.SelectMany(
            regionAreaPair => regionAreaPair.Value.SelectMany(
                areaTownPair => areaTownPair.Value.Select(
                    town => new VehicleLocationTown(town.Key)
                    {
                        LocationRegionId = regions.Single(
                            r => r.Name.Equals(regionAreaPair.Key)).Id,
                        LocationAreaId = areas.Single(
                            r => r.Name.Equals(areaTownPair.Key)).Id,
                        LocationTownTypeId = town.Value.Equals("M") 
                            ? townTypes.Single(type => type.Name.Equals("Місто")).Id
                            : town.Value.Equals("C") 
                                ? townTypes.Single(type => type.Name.Equals("Село")).Id
                                : townTypes.Single(type => type.Name.Equals("Селище")).Id
                    }))).ToList();
    }
}
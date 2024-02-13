using Persistence.DataModels;

namespace Persistence.SeedingData;

internal static class SeedDisplacements
{
    public static List<VehicleDisplacementDataModel> GetDisplacements()
    {
        var displacements = new List<VehicleDisplacementDataModel>();

        for (var i = 1.0; i <= 10; i += 0.1)
            displacements.Add(new VehicleDisplacementDataModel(i));

        return displacements;
    }
}
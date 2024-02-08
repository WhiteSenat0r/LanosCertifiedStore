using Domain.Entities.VehicleRelated.Classes;

namespace Persistence.SeedingData;

internal static class SeedDisplacements
{
    public static List<VehicleDisplacement> GetDisplacements()
    {
        var displacements = new List<VehicleDisplacement>();

        for (var i = 1.0; i <= 10; i += 0.1)
            displacements.Add(new VehicleDisplacement(i));

        return displacements;
    }
}
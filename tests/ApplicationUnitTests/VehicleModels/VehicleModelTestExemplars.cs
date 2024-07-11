using Application.VehicleModels.Commands.CreateVehicleModelRelated;

namespace ApplicationUnitTests.VehicleModels;

internal static class VehicleModelTestExemplars
{
    public static CreateVehicleModelCommandRequest Regular()
    {
        return new CreateVehicleModelCommandRequest(
            "test model",
            Guid.NewGuid(),
            Guid.NewGuid(),
            2004,
            2024,
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()]
        );
    }

    public static CreateVehicleModelCommandRequest WithEmptyName()
    {
        return Regular() with { Name = string.Empty };
    }


    public static CreateVehicleModelCommandRequest WithTooShortName()
    {
        return Regular() with { Name = "A" };
    }


    public static CreateVehicleModelCommandRequest WithTooLongName()
    {
        return Regular() with { Name = new string('A', 65) };
    }

    public static CreateVehicleModelCommandRequest WithProductionYears(
        int minimalProductionYear,
        int maximumProductionYear)
    {
        return Regular() with
        {
            MinimalProductionYear = minimalProductionYear,
            MaximumProductionYear = maximumProductionYear
        };
    }
}
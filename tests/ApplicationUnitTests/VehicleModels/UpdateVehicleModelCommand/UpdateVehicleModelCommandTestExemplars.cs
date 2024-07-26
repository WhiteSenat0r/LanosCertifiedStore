using LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;

namespace ApplicationUnitTests.VehicleModels.UpdateVehicleModelCommand;

internal static class UpdateVehicleModelCommandTestExemplars
{
    public static UpdateVehicleModelCommandRequest Regular()
    {
        return new UpdateVehicleModelCommandRequest(
            Guid.NewGuid(),
            2004,
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()],
            [Guid.NewGuid(), Guid.NewGuid()]
        );
    }
}
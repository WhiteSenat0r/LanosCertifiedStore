using LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.Persistence.Commands.VehicleBrandRelated;

public sealed class UpdateVehicleBrandCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(UpdateVehicleBrandCommandRequest updateVehicleBrandCommandRequest)
    {
        var vehicleBrand = await context
            .VehiclesBrands
            .FindAsync(updateVehicleBrandCommandRequest.Id);

        if (vehicleBrand is null)
        {
            throw new KeyNotFoundException();
        }

        vehicleBrand.Name = updateVehicleBrandCommandRequest.UpdatedName;
    }
}
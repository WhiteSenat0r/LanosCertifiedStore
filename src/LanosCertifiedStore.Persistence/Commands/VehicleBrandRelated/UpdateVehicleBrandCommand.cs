using Application.CommandRequests.VehicleBrandsRelated.UpdateVehicleBrandRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.VehicleBrandRelated;

public sealed class UpdateVehicleBrandCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(
        UpdateVehicleBrandCommandRequest updateVehicleBrandCommandRequest)
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
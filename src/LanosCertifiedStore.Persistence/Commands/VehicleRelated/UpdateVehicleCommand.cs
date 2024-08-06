using LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicleCommandRequestRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Persistence.Commands.VehicleRelated;

public sealed class UpdateVehicleCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(UpdateVehicleCommandRequest request)
    {
        var vehicle = await context
            .Set<Vehicle>()
            .Include(v => v.Prices)
            .SingleOrDefaultAsync(v => v.Id == request.Id);

        if (vehicle is null)
        {
            throw new KeyNotFoundException();
        }

        vehicle.ColorId = request.ColorId;
        vehicle.BodyTypeId = request.BodyTypeId;
        vehicle.EngineTypeId = request.EngineTypeId;
        vehicle.TransmissionTypeId = request.TransmissionTypeId;
        vehicle.DrivetrainTypeId = request.DrivetrainTypeId;
        vehicle.LocationTownId = request.LocationTownId;
        vehicle.Description = request.Description;
        vehicle.Displacement = request.Displacement;
        vehicle.ProductionYear = request.ProductionYear;
        vehicle.Mileage = request.Mileage;

        if (IsAlteredPrice(vehicle, request))
        {
            var price = new VehiclePrice(vehicle.Id, request.Price);
            await context.Set<VehiclePrice>().AddAsync(price);
            vehicle.Prices.Add(price);
        }

        context.Set<Vehicle>().Update(vehicle);
    }

    private static bool IsAlteredPrice(Vehicle vehicle, UpdateVehicleCommandRequest request)
    {
        return vehicle.Prices.OrderByDescending(p => p.IssueDate).First().Value != request.Price;
    }
}
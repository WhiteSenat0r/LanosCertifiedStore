using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Vehicles;

public interface IVehicleService
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
}
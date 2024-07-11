using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTransmissionTypes
{
    public static List<VehicleTransmissionType> GetVehicleTransmissionTypes() =>
    [
        new VehicleTransmissionType("Механіка"),
        new VehicleTransmissionType("Автомат"),
        new VehicleTransmissionType("Варіатор"),
        new VehicleTransmissionType("Типтронік"),
        new VehicleTransmissionType("Робот"),
    ];
}
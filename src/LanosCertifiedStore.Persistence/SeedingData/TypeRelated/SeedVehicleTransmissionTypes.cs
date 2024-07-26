using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Persistence.SeedingData.TypeRelated;

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
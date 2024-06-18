using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTransmissionTypes
{
    public static List<VehicleTransmissionTypeEntity> GetVehicleTransmissionTypes() =>
    [
        new VehicleTransmissionTypeEntity("Механіка"),
        new VehicleTransmissionTypeEntity("Автомат"),
        new VehicleTransmissionTypeEntity("Варіатор"),
        new VehicleTransmissionTypeEntity("Типтронік"),
        new VehicleTransmissionTypeEntity("Робот"),
    ];
}
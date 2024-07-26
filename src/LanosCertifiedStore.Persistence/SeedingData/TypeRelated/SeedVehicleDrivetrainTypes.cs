using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleDrivetrainTypes
{
    public static List<VehicleDrivetrainType> GetVehicleDrivetrainTypes() =>
    [
        new VehicleDrivetrainType("Передній"),
        new VehicleDrivetrainType("Задній"),
        new VehicleDrivetrainType("Повний")
    ];
}

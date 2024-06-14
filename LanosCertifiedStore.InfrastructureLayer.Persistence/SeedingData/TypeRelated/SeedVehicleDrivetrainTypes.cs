using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleDrivetrainTypes
{
    public static List<VehicleDrivetrainTypeEntity> GetVehicleDrivetrainTypes() =>
    [
        new VehicleDrivetrainTypeEntity("Передній"),
        new VehicleDrivetrainTypeEntity("Задній"),
        new VehicleDrivetrainTypeEntity("Повний")
    ];
}

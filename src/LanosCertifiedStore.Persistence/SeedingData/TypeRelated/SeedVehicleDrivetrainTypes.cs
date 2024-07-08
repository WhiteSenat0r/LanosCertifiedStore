using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleDrivetrainTypes
{
    public static List<VehicleDrivetrainType> GetVehicleDrivetrainTypes() =>
    [
        new VehicleDrivetrainType("Передній"),
        new VehicleDrivetrainType("Задній"),
        new VehicleDrivetrainType("Повний")
    ];
}

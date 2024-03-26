using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleDrivetrainTypes
{
    public static List<VehicleDrivetrainTypeDataModel> GetVehicleDrivetrainTypes() =>
    [
        new VehicleDrivetrainTypeDataModel("Передній"),
        new VehicleDrivetrainTypeDataModel("Задній"),
        new VehicleDrivetrainTypeDataModel("Повний")
    ];
}

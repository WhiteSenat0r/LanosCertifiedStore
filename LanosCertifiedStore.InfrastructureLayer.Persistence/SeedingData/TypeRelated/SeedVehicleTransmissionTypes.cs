using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTransmissionTypes
{
    public static List<VehicleTransmissionTypeDataModel> GetVehicleTransmissionTypes() =>
    [
        new VehicleTransmissionTypeDataModel("Механіка"),
        new VehicleTransmissionTypeDataModel("Автомат"),
        new VehicleTransmissionTypeDataModel("Варіатор"),
        new VehicleTransmissionTypeDataModel("Типтронік"),
        new VehicleTransmissionTypeDataModel("Робот"),
    ];
}
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTypes
{
    public static List<VehicleTypeDataModel> GetVehicleTypes() =>
    [
        new VehicleTypeDataModel("Легковик"),
        new VehicleTypeDataModel("Автобус"),
        new VehicleTypeDataModel("Вантажівка"),
    ];
}

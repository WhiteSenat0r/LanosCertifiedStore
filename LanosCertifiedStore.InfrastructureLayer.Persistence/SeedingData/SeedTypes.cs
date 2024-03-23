using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData;

internal static class SeedTypes
{
    public static List<VehicleTypeDataModel> GetTypes() =>
    [
        new VehicleTypeDataModel("Легковик"),
        new VehicleTypeDataModel("Автобус"),
        new VehicleTypeDataModel("Вантажівка"),
    ];
}

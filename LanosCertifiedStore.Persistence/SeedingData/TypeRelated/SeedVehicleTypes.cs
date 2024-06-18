using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTypes
{
    public static List<VehicleTypeEntity> GetVehicleTypes() =>
    [
        new VehicleTypeEntity("Легковик"),
        new VehicleTypeEntity("Автобус"),
        new VehicleTypeEntity("Вантажівка"),
    ];
}

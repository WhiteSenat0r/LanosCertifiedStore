using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTypes
{
    public static List<VehicleType> GetVehicleTypes() =>
    [
        new VehicleType("Легковик"),
        new VehicleType("Автобус"),
        new VehicleType("Вантажівка"),
    ];
}

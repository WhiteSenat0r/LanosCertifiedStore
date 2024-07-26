using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleTypes
{
    public static List<VehicleType> GetVehicleTypes() =>
    [
        new VehicleType("Легковик"),
        new VehicleType("Автобус"),
        new VehicleType("Вантажівка"),
    ];
}

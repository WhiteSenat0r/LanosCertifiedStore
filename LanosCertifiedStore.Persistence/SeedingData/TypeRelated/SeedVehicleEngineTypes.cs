using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleEngineTypes
{
    public static List<VehicleEngineTypeEntity> GetVehicleEngineTypes() =>
    [
        new VehicleEngineTypeEntity("Бензиновий"),
        new VehicleEngineTypeEntity("Бензиновий / газовий (метан)"),
        new VehicleEngineTypeEntity("Бензиновий / газовий (пропан-бутан)"),
        new VehicleEngineTypeEntity("Дизельний"),
        new VehicleEngineTypeEntity("Гібридний (HEV)"),
        new VehicleEngineTypeEntity("Гібридний (MHEV)"),
        new VehicleEngineTypeEntity("Гібридний (PHEV)"),
        new VehicleEngineTypeEntity("Газовий"),
        new VehicleEngineTypeEntity("Електро"),
    ];
}
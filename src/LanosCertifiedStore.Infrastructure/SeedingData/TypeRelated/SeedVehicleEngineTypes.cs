using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Infrastructure.SeedingData.TypeRelated;

internal static class SeedVehicleEngineTypes
{
    public static List<VehicleEngineType> GetVehicleEngineTypes() =>
    [
        new VehicleEngineType("Бензиновий"),
        new VehicleEngineType("Бензиновий / газовий (метан)"),
        new VehicleEngineType("Бензиновий / газовий (пропан-бутан)"),
        new VehicleEngineType("Дизельний"),
        new VehicleEngineType("Гібридний (HEV)"),
        new VehicleEngineType("Гібридний (MHEV)"),
        new VehicleEngineType("Гібридний (PHEV)"),
        new VehicleEngineType("Газовий"),
        new VehicleEngineType("Електро"),
    ];
}
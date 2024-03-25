using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleEngineTypes
{
    public static List<VehicleEngineTypeDataModel> GetVehicleEngineTypes() =>
    [
        new VehicleEngineTypeDataModel("Бензиновий"),
        new VehicleEngineTypeDataModel("Бензиновий / газовий (метан)"),
        new VehicleEngineTypeDataModel("Бензиновий / газовий (пропан-бутан)"),
        new VehicleEngineTypeDataModel("Дизельний"),
        new VehicleEngineTypeDataModel("Гібридний (HEV)"),
        new VehicleEngineTypeDataModel("Гібридний (MHEV)"),
        new VehicleEngineTypeDataModel("Гібридний (PHEV)"),
        new VehicleEngineTypeDataModel("Газовий"),
        new VehicleEngineTypeDataModel("Електро"),
    ];
}
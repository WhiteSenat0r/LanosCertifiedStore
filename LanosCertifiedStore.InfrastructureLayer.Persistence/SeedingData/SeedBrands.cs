using Persistence.DataModels.VehicleRelated;

namespace Persistence.SeedingData;

internal static class SeedBrands
{
    public static List<VehicleBrandDataModel> GetBrands() =>
    [
        new VehicleBrandDataModel("Toyota"),
        new VehicleBrandDataModel("Ford"),
        new VehicleBrandDataModel("Honda"),
        new VehicleBrandDataModel("Chevrolet"),
        new VehicleBrandDataModel("Volkswagen"),
        new VehicleBrandDataModel("Nissan"),
        new VehicleBrandDataModel("BMW"),
        new VehicleBrandDataModel("Mercedes-Benz"),
        new VehicleBrandDataModel("Audi"),
        new VehicleBrandDataModel("Hyundai"),
        new VehicleBrandDataModel("Kia"),
        new VehicleBrandDataModel("Mazda"),
        new VehicleBrandDataModel("Subaru"),
        new VehicleBrandDataModel("Lexus"),
        new VehicleBrandDataModel("Jeep"),
        new VehicleBrandDataModel("Tesla"),
        new VehicleBrandDataModel("Volvo"),
        new VehicleBrandDataModel("Porsche"),
        new VehicleBrandDataModel("Ferrari"),
        new VehicleBrandDataModel("Jaguar")
    ];
}
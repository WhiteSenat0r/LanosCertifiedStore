using Persistence.Entities.VehicleRelated;

namespace Persistence.SeedingData;

internal static class SeedBrands
{
    public static List<VehicleBrandEntity> GetBrands() =>
    [
        new VehicleBrandEntity("Toyota"),
        new VehicleBrandEntity("Ford"),
        new VehicleBrandEntity("Honda"),
        new VehicleBrandEntity("Chevrolet"),
        new VehicleBrandEntity("Volkswagen"),
        new VehicleBrandEntity("Nissan"),
        new VehicleBrandEntity("BMW"),
        new VehicleBrandEntity("Mercedes-Benz"),
        new VehicleBrandEntity("Audi"),
        new VehicleBrandEntity("Hyundai"),
        new VehicleBrandEntity("Kia"),
        new VehicleBrandEntity("Mazda"),
        new VehicleBrandEntity("Subaru"),
        new VehicleBrandEntity("Lexus"),
        new VehicleBrandEntity("Jeep"),
        new VehicleBrandEntity("Tesla"),
        new VehicleBrandEntity("Volvo"),
        new VehicleBrandEntity("Porsche"),
        new VehicleBrandEntity("Ferrari"),
        new VehicleBrandEntity("Jaguar")
    ];
}
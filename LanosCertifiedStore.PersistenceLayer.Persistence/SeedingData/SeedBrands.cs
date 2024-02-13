using Domain.Entities.VehicleRelated.Classes;

namespace Persistence.SeedingData;

internal static class SeedBrands
{
    public static List<VehicleBrand> GetBrands() =>
    [
        new VehicleBrand("Toyota"),
        new VehicleBrand("Ford"),
        new VehicleBrand("Honda"),
        new VehicleBrand("Chevrolet"),
        new VehicleBrand("Volkswagen"),
        new VehicleBrand("Nissan"),
        new VehicleBrand("BMW"),
        new VehicleBrand("Mercedes-Benz"),
        new VehicleBrand("Audi"),
        new VehicleBrand("Hyundai"),
        new VehicleBrand("Kia"),
        new VehicleBrand("Mazda"),
        new VehicleBrand("Subaru"),
        new VehicleBrand("Lexus"),
        new VehicleBrand("Jeep"),
        new VehicleBrand("Tesla"),
        new VehicleBrand("Volvo"),
        new VehicleBrand("Porsche"),
        new VehicleBrand("Ferrari"),
        new VehicleBrand("Jaguar")
    ];
}
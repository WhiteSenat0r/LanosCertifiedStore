using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleBodyTypes
{
    public static List<VehicleBodyType> GetVehicleBodyTypes() =>
    [
        new VehicleBodyType("Седан"),
        new VehicleBodyType("Хетчбек"),
        new VehicleBodyType("Ліфтбек"),
        new VehicleBodyType("Купе"),
        new VehicleBodyType("Універсал"),
        new VehicleBodyType("Кросовер"),
        new VehicleBodyType("Мінівен"),
        new VehicleBodyType("Пікап"),
        new VehicleBodyType("Кабріолет"),
        new VehicleBodyType("Фургон"),
    ];
}
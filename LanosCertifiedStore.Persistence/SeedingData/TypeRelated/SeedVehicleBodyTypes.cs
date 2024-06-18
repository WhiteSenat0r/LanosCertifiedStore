using Persistence.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleBodyTypes
{
    public static List<VehicleBodyTypeEntity> GetVehicleBodyTypes() =>
    [
        new VehicleBodyTypeEntity("Седан"),
        new VehicleBodyTypeEntity("Хетчбек"),
        new VehicleBodyTypeEntity("Ліфтбек"),
        new VehicleBodyTypeEntity("Купе"),
        new VehicleBodyTypeEntity("Універсал"),
        new VehicleBodyTypeEntity("Кросовер"),
        new VehicleBodyTypeEntity("Мінівен"),
        new VehicleBodyTypeEntity("Пікап"),
        new VehicleBodyTypeEntity("Кабріолет"),
        new VehicleBodyTypeEntity("Фургон"),
    ];
}
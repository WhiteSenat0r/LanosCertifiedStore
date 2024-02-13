using Domain.Entities.VehicleRelated.Classes;

namespace Persistence.SeedingData;

internal static class SeedTypes
{
    public static List<VehicleType> GetTypes() =>
    [
        new VehicleType("Седан"),
        new VehicleType("Хетчбек"),
        new VehicleType("Купе"),
        new VehicleType("Універсал"),
        new VehicleType("Кросовер"),
        new VehicleType("Спорткар"),
        new VehicleType("Позашляховик"),
        new VehicleType("Мінівен"),
        new VehicleType("Пікап"),
        new VehicleType("Лімузин"),
        new VehicleType("Кабріолет"),
        new VehicleType("Фургон"),
        new VehicleType("Компактвен"),
        new VehicleType("Електромобіль"),
        new VehicleType("Гібрид"),
        new VehicleType("Конвертібл"),
        new VehicleType("Автобус"),
        new VehicleType("Вантажівка"),
    ];
}

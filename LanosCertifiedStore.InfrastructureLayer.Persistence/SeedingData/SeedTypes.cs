using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData;

internal static class SeedTypes
{
    public static List<VehicleTypeDataModel> GetTypes() =>
    [
        new VehicleTypeDataModel("Седан"),
        new VehicleTypeDataModel("Хетчбек"),
        new VehicleTypeDataModel("Купе"),
        new VehicleTypeDataModel("Універсал"),
        new VehicleTypeDataModel("Кросовер"),
        new VehicleTypeDataModel("Спорткар"),
        new VehicleTypeDataModel("Позашляховик"),
        new VehicleTypeDataModel("Мінівен"),
        new VehicleTypeDataModel("Пікап"),
        new VehicleTypeDataModel("Лімузин"),
        new VehicleTypeDataModel("Кабріолет"),
        new VehicleTypeDataModel("Фургон"),
        new VehicleTypeDataModel("Компактвен"),
        new VehicleTypeDataModel("Електромобіль"),
        new VehicleTypeDataModel("Гібрид"),
        new VehicleTypeDataModel("Конвертібл"),
        new VehicleTypeDataModel("Автобус"),
        new VehicleTypeDataModel("Вантажівка"),
    ];
}

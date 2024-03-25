using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData.TypeRelated;

internal static class SeedVehicleBodyTypes
{
    public static List<VehicleBodyTypeDataModel> GetVehicleBodyTypes() =>
    [
        new VehicleBodyTypeDataModel("Седан"),
        new VehicleBodyTypeDataModel("Хетчбек"),
        new VehicleBodyTypeDataModel("Ліфтбек"),
        new VehicleBodyTypeDataModel("Купе"),
        new VehicleBodyTypeDataModel("Універсал"),
        new VehicleBodyTypeDataModel("Кросовер"),
        new VehicleBodyTypeDataModel("Мінівен"),
        new VehicleBodyTypeDataModel("Пікап"),
        new VehicleBodyTypeDataModel("Кабріолет"),
        new VehicleBodyTypeDataModel("Фургон"),
    ];
}
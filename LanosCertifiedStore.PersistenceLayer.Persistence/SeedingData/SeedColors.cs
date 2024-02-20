using Persistence.DataModels;

namespace Persistence.SeedingData;

internal static class SeedColors
{
    public static List<VehicleColorDataModel> GetColors() =>
    [
        new VehicleColorDataModel("Білий", "#FFFFFF"),
        new VehicleColorDataModel("Чорний", "#000000"),
        new VehicleColorDataModel("Червоний", "#FF0000"),
        new VehicleColorDataModel("Жовтий", "#FFFF00"),
        new VehicleColorDataModel("Синій", "#0000FF"),
        new VehicleColorDataModel("Сріблястий", "#C0C0C0"),
        new VehicleColorDataModel("Зелений", "#008000"),
        new VehicleColorDataModel("Помаранчевий", "#FFA500"),
        new VehicleColorDataModel("Сірий", "#808080"),
        new VehicleColorDataModel("Коричневий", "#A52A2A"),
        new VehicleColorDataModel("Рожевий", "#FFC0CB"),
        new VehicleColorDataModel("Блакитний", "#00FFFF"),
        new VehicleColorDataModel("Лаймовий", "#00FF00"),
        new VehicleColorDataModel("Бірюзовий", "#40E0D0"),
        new VehicleColorDataModel("Індиґо", "#4B0082"),
        new VehicleColorDataModel("Коричнево-червоний", "#8B4513"),
        new VehicleColorDataModel("Темно-синій", "#00008B"),
        new VehicleColorDataModel("Оливковий", "#808000"),
        new VehicleColorDataModel("Бежевий", "#F5F5DC"),
        new VehicleColorDataModel("Блакитно-зелений", "#008080"),
        new VehicleColorDataModel("Лаванда", "#E6E6FA"),
        new VehicleColorDataModel("Лосось", "#FA8072"),
        new VehicleColorDataModel("Фіолетовий", "#800080"),
        new VehicleColorDataModel("Хакі", "#C3B091"),
        new VehicleColorDataModel("Аквамарин", "#7FFFD4"),
        new VehicleColorDataModel("Кораловий", "#FF6F61"),
        new VehicleColorDataModel("Золотий", "#FFD700"),
        new VehicleColorDataModel("Томатний", "#FF6347")
    ];
}
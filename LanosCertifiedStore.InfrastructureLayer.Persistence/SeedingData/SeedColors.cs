using Persistence.Entities.VehicleRelated;

namespace Persistence.SeedingData;

internal static class SeedColors
{
    public static List<VehicleColorEntity> GetColors() =>
    [
        new VehicleColorEntity("Білий", "#FFFFFF"),
        new VehicleColorEntity("Чорний", "#000000"),
        new VehicleColorEntity("Червоний", "#FF0000"),
        new VehicleColorEntity("Жовтий", "#FFFF00"),
        new VehicleColorEntity("Синій", "#0000FF"),
        new VehicleColorEntity("Сріблястий", "#C0C0C0"),
        new VehicleColorEntity("Зелений", "#008000"),
        new VehicleColorEntity("Помаранчевий", "#FFA500"),
        new VehicleColorEntity("Сірий", "#808080"),
        new VehicleColorEntity("Коричневий", "#A52A2A"),
        new VehicleColorEntity("Рожевий", "#FFC0CB"),
        new VehicleColorEntity("Блакитний", "#00FFFF"),
        new VehicleColorEntity("Лаймовий", "#00FF00"),
        new VehicleColorEntity("Бірюзовий", "#40E0D0"),
        new VehicleColorEntity("Індиґо", "#4B0082"),
        new VehicleColorEntity("Коричнево-червоний", "#8B4513"),
        new VehicleColorEntity("Темно-синій", "#00008B"),
        new VehicleColorEntity("Оливковий", "#808000"),
        new VehicleColorEntity("Бежевий", "#F5F5DC"),
        new VehicleColorEntity("Блакитно-зелений", "#008080"),
        new VehicleColorEntity("Лаванда", "#E6E6FA"),
        new VehicleColorEntity("Лосось", "#FA8072"),
        new VehicleColorEntity("Фіолетовий", "#800080"),
        new VehicleColorEntity("Хакі", "#C3B091"),
        new VehicleColorEntity("Аквамарин", "#7FFFD4"),
        new VehicleColorEntity("Кораловий", "#FF6F61"),
        new VehicleColorEntity("Золотий", "#FFD700"),
        new VehicleColorEntity("Томатний", "#FF6347")
    ];
}
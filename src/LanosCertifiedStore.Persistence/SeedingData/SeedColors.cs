using Domain.Entities.VehicleRelated;

namespace Persistence.SeedingData;

internal static class SeedColors
{
    public static List<VehicleColor> GetColors() =>
    [
        new VehicleColor("Білий", "#FFFFFF"),
        new VehicleColor("Чорний", "#000000"),
        new VehicleColor("Червоний", "#FF0000"),
        new VehicleColor("Жовтий", "#FFFF00"),
        new VehicleColor("Синій", "#0000FF"),
        new VehicleColor("Сріблястий", "#C0C0C0"),
        new VehicleColor("Зелений", "#008000"),
        new VehicleColor("Помаранчевий", "#FFA500"),
        new VehicleColor("Сірий", "#808080"),
        new VehicleColor("Коричневий", "#A52A2A"),
        new VehicleColor("Рожевий", "#FFC0CB"),
        new VehicleColor("Блакитний", "#00FFFF"),
        new VehicleColor("Лаймовий", "#00FF00"),
        new VehicleColor("Бірюзовий", "#40E0D0"),
        new VehicleColor("Індиґо", "#4B0082"),
        new VehicleColor("Коричнево-червоний", "#8B4513"),
        new VehicleColor("Темно-синій", "#00008B"),
        new VehicleColor("Оливковий", "#808000"),
        new VehicleColor("Бежевий", "#F5F5DC"),
        new VehicleColor("Блакитно-зелений", "#008080"),
        new VehicleColor("Лаванда", "#E6E6FA"),
        new VehicleColor("Лосось", "#FA8072"),
        new VehicleColor("Фіолетовий", "#800080"),
        new VehicleColor("Хакі", "#C3B091"),
        new VehicleColor("Аквамарин", "#7FFFD4"),
        new VehicleColor("Кораловий", "#FF6F61"),
        new VehicleColor("Золотий", "#FFD700"),
        new VehicleColor("Томатний", "#FF6347")
    ];
}
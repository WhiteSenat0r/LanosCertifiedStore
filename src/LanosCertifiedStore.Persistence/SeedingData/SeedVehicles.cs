using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.LocationRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated.TypeRelated;

namespace LanosCertifiedStore.Persistence.SeedingData;

internal static class SeedVehicles
{
    public static List<Vehicle> GetVehicles(
        List<VehicleType> types,
        List<VehicleColor> colors,
        List<VehicleBrand> brands,
        List<VehicleModel> models,
        List<VehicleBodyType> bodyTypes,
        List<VehicleDrivetrainType> drivetrainTypes,
        List<VehicleEngineType> engineTypes,
        List<VehicleTransmissionType> transmissionTypes,
        List<VehicleLocationRegion> regions,
        List<VehicleLocationArea> areas,
        List<VehicleLocationTown> towns) =>
    [
        new Vehicle(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            models.Single(m => m.Name.Equals("Camry")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Передній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Гібридний (HEV)")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Варіатор")).Id,
            colorId: colors.First(x => x.Name.Equals("Чорний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Київ")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Київ")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Київ")).Id)).Id,
            productionYear: 2019,
            mileage: 64385,
            displacement: 2.5d,
            price: 30000,
            description: "Продам свою Toyota Camry..........................................................."
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            models.Single(m => m.Name.Equals("F-150")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Пікап")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Білий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Ірпінь")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Бучанський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Київська")).Id)).Id,
            productionYear: 2020,
            mileage: 74690,
            displacement: 2.9d,
            price: 45000,
            description: "Опис Ford F-150)))))))))))))))))))))))))))))))))))))))))))))))))))"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            models.Single(m => m.Name.Equals("Civic")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Купе")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Передній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Жовтий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Ірпінь")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Бучанський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Київська")).Id)).Id,
            productionYear: 2020,
            mileage: 74690,
            displacement: 2.0d,
            price: 28000,
            description: "ХОНДА КІВІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІК"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            models.Single(m => m.Name.Equals("Silverado")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Пікап")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Дизельний")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Синій")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Рівне")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Рівненський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Рівненська")).Id)).Id,
            productionYear: 2021,
            mileage: 174690,
            price: 55000,
            displacement: 6.2d,
            description: "ЧЕВРОЛЄТ СЮЛЬВЄРАДО СИНІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            models.Single(m => m.Name.Equals("Silverado")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Пікап")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Задній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Білий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Олександрія")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Рівненський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Рівненська")).Id)).Id,
            productionYear: 2020,
            mileage: 375690,
            price: 41000,
            displacement: 5.0d,
            description: "ЧЕВРОЛЄТ СЮЛЬВЄРАДО БІЛІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            models.Single(m => m.Name.Equals("Passat")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Передній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Чорний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Ковель")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Ковельський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Волинська")).Id)).Id,
            productionYear: 2016,
            mileage: 215690,
            price: 27000,
            displacement: 2.0d,
            description: "ПАССАТІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІК"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            models.Single(m => m.Name.Equals("Passat")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Передній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Сірий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Луцьк")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Луцький")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Волинська")).Id)).Id,
            productionYear: 2017,
            mileage: 115450,
            price: 29000,
            displacement: 2.0d,
            description: "ПАССАТІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІК"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            models.Single(m => m.Name.Equals("Altima")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Гібридний (HEV)")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Червоний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Хмельницький")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Хмельницький")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Хмельницька")).Id)).Id,
            productionYear: 2019,
            mileage: 77450,
            price: 31000,
            displacement: 2.4d,
            description: "НІСАН АЛЬТІМА ЧЕРВОНИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            models.Single(m => m.Name.Equals("M3")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Білий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Дніпро")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Дніпровський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Дніпропетровська")).Id)).Id,
            productionYear: 2022,
            mileage: 10450,
            price: 75000,
            displacement: 3.0d,
            description: "БЕМЕР БІЛИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            models.Single(m => m.Name.Equals("C-Class")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Чорний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Дніпро")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Дніпровський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Дніпропетровська")).Id)).Id,
            productionYear: 2019,
            mileage: 8060,
            price: 58000,
            displacement: 3d,
            description: "МЕРКЕДЕК БЕНК ЧОРНИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            models.Single(m => m.Name.Equals("C-Class")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Кабріолет")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Чорний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Чернівці")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Чернівецький")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Чернівецька")).Id)).Id,
            productionYear: 2017,
            mileage: 3000,
            price: 78000,
            displacement: 4.0d,
            description: "МЕРКЕДЕК БЕНК ЧОРНИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            models.Single(m => m.Name.Equals("C-Class")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Задній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Дизельний")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Механіка")).Id,
            colorId: colors.First(x => x.Name.Equals("Сріблястий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Житомир")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Житомирський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Житомирська")).Id)).Id,
            productionYear: 2019,
            mileage: 136055,
            price: 46000,
            displacement: 2.0d,
            description: "МЕРКЕДЕК БЕНК СІЛЬВЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕР"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            models.Single(m => m.Name.Equals("C-Class")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Синій")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Коростень")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Коростенський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Житомирська")).Id)).Id,
            productionYear: 2019,
            mileage: 13055,
            price: 80000,
            displacement: 4.0d,
            description: "МЕРКЕДЕК БЕНК СИНІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІІЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            models.Single(m => m.Name.Equals("A6")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Дизельний")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Індиґо")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Рівне")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Рівненський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Рівненська")).Id)).Id,
            productionYear: 2019,
            mileage: 13055,
            price: 64000,
            displacement: 3.0d,
            description: "АУДІ ІНДИГООООООООООООООООООООООООООООООООООООООООООООО"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            models.Single(m => m.Name.Equals("A6")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Передній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий / газовий (пропан-бутан)")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Механіка")).Id,
            colorId: colors.First(x => x.Name.Equals("Білий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Рівне")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Рівненський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Рівненська")).Id)).Id,
            productionYear: 2021,
            mileage: 48142,
            price: 57000,
            displacement: 2.0,
            description: "АУДІ БІЛАААААААААААААААААААААААААААААААААААААААААААААААААААААААААА"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            models.Single(m => m.Name.Equals("A6")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Універсал")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Гібридний (HEV)")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Робот")).Id,
            colorId: colors.First(x => x.Name.Equals("Червоний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Київ")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Київ")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Київ")).Id)).Id,
            productionYear: 2022,
            mileage: 9142,
            price: 70000,
            displacement: 3.0d,
            description: "АУДІ ЧЕРВОНААААААААААААААААААААААААААААААААААААААААААААААААААААА"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            models.Single(m => m.Name.Equals("A6")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Повний")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Дизельний")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Механіка")).Id,
            colorId: colors.First(x => x.Name.Equals("Сірий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Полтава")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Полтавський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Полтавська")).Id)).Id,
            productionYear: 2021,
            mileage: 25142,
            price: 73000,
            displacement: 3.0d,
            description: "АУДІ СІРАААААААААААААААААААААААААААААААААААААААААААААААААААААААААА"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            models.Single(m => m.Name.Equals("Sonata")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Задній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Сірий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Черкаси")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Черкаський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Черкаська")).Id)).Id,
            productionYear: 2023,
            mileage: 500,
            price: 27000,
            displacement: 2.5d,
            description: "ХУНДАЙ СІРИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            models.Single(m => m.Name.Equals("Sonata")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Задній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Червоний")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Черкаси")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Черкаський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Черкаська")).Id)).Id,
            productionYear: 2023,
            mileage: 1500,
            price: 26500,
            displacement: 2.0d,
            description: "ХУНДАЙ ЧЕРВОНИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙ"
        ),
        new Vehicle(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            models.Single(m => m.Name.Equals("Sonata")).Id,
            types.Single(x => x.Name.Equals("Легковик")).Id,
            bodyTypeId: bodyTypes.Single(b => b.Name.Equals("Седан")).Id,
            drivetrainTypeId: drivetrainTypes.Single(d => d.Name.Equals("Задній")).Id,
            engineTypeId: engineTypes.Single(e => e.Name.Equals("Бензиновий")).Id,
            transmissionTypeId: transmissionTypes.Single(t => t.Name.Equals("Автомат")).Id,
            colorId: colors.First(x => x.Name.Equals("Білий")).Id,
            locationTownId: towns.Single(
                t => t.Name.Equals("Харків")
                     && t.LocationAreaId.Equals(areas.Single(a => a.Name.Equals("Харківський")).Id)
                     && t.LocationRegionId.Equals(regions.Single(a => a.Name.Equals("Харківська")).Id)).Id,
            productionYear: 2023,
            mileage: 8000,
            price: 24000,
            displacement: 2.0d,
            description: "ХУНДАЙ БІЛИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИИЙЙЙЙЙЙЙЙЙЙЙЙЙ"
        )
    ];
}
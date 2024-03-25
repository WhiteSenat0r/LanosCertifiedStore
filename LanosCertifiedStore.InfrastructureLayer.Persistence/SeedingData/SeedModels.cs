using Persistence.DataModels.Common.Classes;
using Persistence.DataModels.VehicleRelated;
using Persistence.DataModels.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData;

internal static class SeedModels
{
    public static List<VehicleModelDataModel> GetModels(
        List<VehicleBrandDataModel> brands,
        List<VehicleTypeDataModel> vehicleTypes,
        List<VehicleEngineTypeDataModel> engineTypes,
        List<VehicleBodyTypeDataModel> bodyTypes,
        List<VehicleDrivetrainTypeDataModel> drivetrainTypes,
        List<VehicleTransmissionTypeDataModel> transmissionTypes) =>
    [
        #region Toyota

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Camry",
            GetObjectsWithSelectedIds(
                engineTypes.SkipWhile(e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(drivetrainTypes),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
            ]), 1982),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Corolla",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(drivetrainTypes),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Купе")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
                bodyTypes.Single(t => t.Name.Equals("Хетчбек")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
            ]), 1966),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "RAV4",
            GetObjectsWithSelectedIds(engineTypes),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 1994),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Highlander",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 2000),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Prius",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
            ]), 1997),

        #endregion

        #region Ford

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "F-150",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Пікап")),
            ]), 1973),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Escape",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Газовий")
                     || e.Name.Equals("Бензиновий / газовий (метан)")
                     || e.Name.Equals("Бензиновий / газовий (пропан-бутан)"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds([bodyTypes.Single(t => t.Name.Equals("Кросовер"))]),
            2000
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Explorer",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер")
                     || !t.Name.Equals("Універсал")
                     || !t.Name.Equals("Фургон")
                     || !t.Name.Equals("Кабріолет"))),
            1991
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Mustang",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Повний"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Купе")
                     || !t.Name.Equals("Кабріолет"))),
            1964
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Focus",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Седан")
                     || !t.Name.Equals("Хетчбек")
                     || !t.Name.Equals("Універсал")
                     || !t.Name.Equals("Кабріолет"))),
            1998
        ),

        #endregion

        #region Honda

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Civic",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Купе")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
                bodyTypes.Single(t => t.Name.Equals("Хетчбек")),
                bodyTypes.Single(t => t.Name.Equals("Універсал"))
            ]), 1972),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Accord",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Купе")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
                bodyTypes.Single(t => t.Name.Equals("Хетчбек")),
                bodyTypes.Single(t => t.Name.Equals("Універсал"))
            ]), 1976),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "CR-V",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 1995),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Pilot",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)")
                     || e.Name.Equals("Гібридний (HEV)")
                     || e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(
            [
                transmissionTypes.Single(t => t.Name.Equals("Механіка")),
                transmissionTypes.Single(t => t.Name.Equals("Автомат")),
                transmissionTypes.Single(t => t.Name.Equals("Типтронік")),
            ]),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 2002),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Odyssey",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)")
                     || e.Name.Equals("Гібридний (HEV)")
                     || e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(
            [
                transmissionTypes.Single(t => t.Name.Equals("Механіка")),
                transmissionTypes.Single(t => t.Name.Equals("Автомат")),
                transmissionTypes.Single(t => t.Name.Equals("Типтронік")),
            ]),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 2002),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Odyssey",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)")
                     || e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(
            [
                transmissionTypes.Single(t => t.Name.Equals("Механіка")),
                transmissionTypes.Single(t => t.Name.Equals("Автомат")),
                transmissionTypes.Single(t => t.Name.Equals("Варіатор")),
            ]),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Мінівен")),
            ]), 1994),

        #endregion

        #region Chervolet

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Silverado",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік")
                     || t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Повний"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Пікап"))),
            1998
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Malibu",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік")
                     || t.Name.Equals("Робот")
                     || t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кабріолет")
                     || !t.Name.Equals("Купе"))),
            1964
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Equinox",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік")
                     || t.Name.Equals("Робот")
                     || t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе"))),
            2004
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Camaro",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
                     || !e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік")
                     || t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кабріолет")
                     || !t.Name.Equals("Купе"))),
            1966
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Traverse",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер")
                     || !t.Name.Equals("Універсал"))),
            2008
        ),

        #endregion

        #region Volkswagen

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Jetta",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
            ]), 1979),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Passat",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
                bodyTypes.Single(t => t.Name.Equals("Ліфтбек")),
            ]), 1973),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Golf",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кабріолет")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
                bodyTypes.Single(t => t.Name.Equals("Хетчбек")),
            ]), 1974),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Touran",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)")
                     || e.Name.Equals("Гібридний (PHEV)")
                     || e.Name.Equals("Гібридний (HEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Мінівен"))
            ]), 2003),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "ID.4",
            GetObjectsWithSelectedIds(engineTypes.TakeWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Типтронік")
                     || t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер"))
            ]), 2020),

        #endregion

        #region Nissan

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Altima",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе"))),
            1992
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Maxima",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан"))),
            1980
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Sentra",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => !d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Хетчбек"))),
            1982
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Rogue",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер"))),
            2007
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Leaf",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Електро")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => !d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер")
                     || !t.Name.Equals("Хетчбек"))),
            2010
        ),

        #endregion
        
        #region BMW
        
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "3 Series",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кабріолет")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Купе")),
            ]), 1975
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "5 Series",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
            ]), 1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "M3",
            GetObjectsWithSelectedIds(engineTypes.TakeWhile(
                e => e.Name.Equals("Бензиновий"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.TakeWhile(t => t.Name.Equals("Робот") 
                                                 || t.Name.Equals("Автомат") 
                                                 || t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
                bodyTypes.Single(t => t.Name.Equals("Седан")),
            ]), 1986
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "X5",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 1999),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "X3",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
            GetObjectsWithSelectedIds(
                transmissionTypes.SkipWhile(t => t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Кросовер")),
            ]), 2003),
        
        #endregion
        
        #region Mercedes-Benz

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "C-Class",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (PHEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Механіка")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе")
                     || !t.Name.Equals("Кабріолет"))),
            1993
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "E-Class",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (PHEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Механіка")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе")
                     || !t.Name.Equals("Універсал"))),
            1953
        ),

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "S-Class",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (PHEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе"))),
            1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A-Class",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (PHEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан")
                     || !t.Name.Equals("Купе")
                     || !t.Name.Equals("Хетчбек"))),
            1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "CLS",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (PHEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Робот"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Купе")
                     || !t.Name.Equals("Седан"))),
            2004
        ),

        #endregion
        
        #region Audi
        
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A3",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (MHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Хетчбек")),
            ]), 1996),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A4",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (PHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
                bodyTypes.Single(t => t.Name.Equals("Універсал")),
            ]), 1994),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A8",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро")
                     || e.Name.Equals("Гібридний (PHEV)")
                     || e.Name.Equals("Гібридний (MHEV)"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.SkipWhile(d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Седан")),
            ]), 1994),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "R8",
            GetObjectsWithSelectedIds(engineTypes.TakeWhile(
                e => e.Name.Equals("Бензиновий"))),
            GetObjectsWithSelectedIds(transmissionTypes),
            GetObjectsWithSelectedIds(
                drivetrainTypes.TakeWhile(d => d.Name.Equals("Повний"))),
            GetObjectsWithSelectedIds(
            [
                bodyTypes.Single(t => t.Name.Equals("Купе")),
            ]), 2006),
        
        #endregion

        #region Hyundai

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Elantra",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор")
                     || !t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Хетчбек")
                     || !t.Name.Equals("Седан"))),
            1990
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Sonata",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => !d.Name.Equals("Передній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Седан"))),
            1985
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Tucson",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Механіка")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер"))),
            2004
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Santa fe",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Гібридний (HEV)")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Механіка")
                     || !t.Name.Equals("Варіатор"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Кросовер"))),
            2000
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Santa fe",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => !e.Name.Equals("Бензиновий")
                     || !e.Name.Equals("Дизельний")
                     || !e.Name.Equals("Електро")
            )),
            GetObjectsWithSelectedIds(transmissionTypes.SkipWhile(
                t => !t.Name.Equals("Автомат")
                     || !t.Name.Equals("Механіка"))),
            GetObjectsWithSelectedIds(drivetrainTypes.SkipWhile(
                d => d.Name.Equals("Задній"))),
            GetObjectsWithSelectedIds(bodyTypes.SkipWhile(
                t => !t.Name.Equals("Хетчбек"))),
            2017
        )

        #endregion
    ];

    private static List<T> GetObjectsWithSelectedIds<T>(IEnumerable<T> collection)
        where T : NamedVehicleAspect, new() =>
        collection.Select(i => new T
        {
            Id = i.Id
        }).ToList();
}
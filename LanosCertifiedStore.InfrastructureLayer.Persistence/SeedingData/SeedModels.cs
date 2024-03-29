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
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            drivetrainTypes,
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Ліфтбек", "Універсал" ]),
            1982),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Corolla",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            drivetrainTypes,
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1966),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "RAV4",
            GetItemsWithParticularValues(engineTypes, [ ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1994),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Highlander",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2000),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Prius",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Ліфтбек" ]),
            1997),

        #endregion

        #region Ford

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "F-150",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Пікап" ]),
            1973),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Escape",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2000
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Explorer",
            GetItemsWithParticularValues(
                engineTypes, [ "Електро", "Дизельний", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1991
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Mustang",
            GetItemsWithParticularValues(
                engineTypes, 
                [ "Електро", "Дизельний", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)" ],
                true),
            GetItemsWithParticularValues(
                transmissionTypes, [ "Варіатор", "Робот", "Тіптронік" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Кабріолет" ]),
            1964
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Focus",
            GetItemsWithParticularValues(
                engineTypes, [ "Гібридний (HEV)", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(
                bodyTypes, [ "Седан", "Хетчбек", "Універсал", "Кабріолет" ], true),
            1998
        ),

        #endregion

        #region Honda

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Civic",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1972),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Accord",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1976),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "CR-V",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1995),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Pilot",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Автомат", "Типтронік" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2002),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Odyssey",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Автомат", "Варіатор" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Мінівен" ]), 1994),

        #endregion

        #region Chervolet

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Silverado",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Автомат" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Пікап" ]),
            1998
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Malibu",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1978
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Equinox",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Автомат" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2004
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Camaro",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот", "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Кабріолет", "Купе" ]),
            1966
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Chevrolet")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Traverse",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот", "Варіатор", "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2008
        ),

        #endregion

        #region Volkswagen

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Jetta",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1979),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Passat",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал", "Ліфтбек" ]),
            1973),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Golf",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кабріолет", "Універсал", "Хетчбек" ]),
            1974),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Touran",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Мінівен" ]),
            2003),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "ID.4",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ]),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Типтронік" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2020),

        #endregion

        #region Nissan

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Altima",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Дизельний", "Гібридний (HEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе" ]),
            1992
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Maxima",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал" ]),
            1980
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Sentra",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот", "Типтронік" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Седан" ]),
            1982
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Rogue",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2007
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Nissan")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Leaf",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ]),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Хетчбек" ]),
            2010
        ),

        #endregion
        
        #region BMW
        
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "3 Series",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал", "Кабріолет" ]),
            1975
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "5 Series",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "M3",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот", "Автомат", "Механіка" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1986
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "X5",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1999),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "X3",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2003),
        
        #endregion
        
        #region Mercedes-Benz

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "C-Class",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал", "Кабріолет" ]),
            1993
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "E-Class",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал", "Кабріолет" ]),
            1953
        ),

        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "S-Class",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Кабріолет" ]),
            1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A-Class",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Хетчбек" ]),
            1972
        ),
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "CLS",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            2004
        ),

        #endregion
        
        #region Audi
        
        new VehicleModelDataModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A6",
            GetObjectsWithSelectedIds(engineTypes.SkipWhile(
                e => e.Name.Equals("Електро"))),
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
            "Santa Fe",
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
            "Kona",
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
        where T : NamedVehicleAspect => collection.ToList();

    private static List<T> GetItemsWithParticularValues<T>(
        IEnumerable<T> collection,
        IEnumerable<string> nameValues,
        bool skipMode = false) where T : NamedVehicleAspect =>
        skipMode
            ? collection.Where(item => !nameValues.Contains(item.Name)).ToList()
            : collection.Where(item => nameValues.Contains(item.Name)).ToList();
}
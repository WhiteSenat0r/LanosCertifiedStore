using Domain.Entities.Common.Classes;
using Domain.Entities.VehicleRelated;
using Domain.Entities.VehicleRelated.TypeRelated;

namespace Persistence.SeedingData;

internal static class SeedModels
{
    public static List<VehicleModel> GetModels(
        List<VehicleBrand> brands,
        List<VehicleType> vehicleTypes,
        List<VehicleEngineType> engineTypes,
        List<VehicleBodyType> bodyTypes,
        List<VehicleDrivetrainType> drivetrainTypes,
        List<VehicleTransmissionType> transmissionTypes) =>
    [
        #region Toyota

        new VehicleModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Camry",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            drivetrainTypes,
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Ліфтбек", "Універсал" ]),
            1982),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Corolla",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            drivetrainTypes,
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1966),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "RAV4",
            GetItemsWithParticularValues(engineTypes, [ ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1994),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Toyota")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Highlander",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2000),
        new VehicleModel(
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

        new VehicleModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "F-150",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Пікап" ]),
            1973),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Ford")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Escape",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2000
        ),
        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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

        new VehicleModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Civic",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1972),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Accord",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Купе", "Седан", "Ліфтбек", "Хетчбек", "Універсал" ]),
            1976),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "CR-V",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1995),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Honda")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Pilot",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)", "Дизельний" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Механіка", "Автомат", "Типтронік" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2002),
        new VehicleModel(
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

        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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

        new VehicleModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Jetta",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1979),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Passat",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал", "Ліфтбек" ]),
            1973),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Golf",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кабріолет", "Універсал", "Хетчбек" ]),
            1974),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Volkswagen")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Touran",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (MHEV)", "Гібридний (PHEV)", "Гібридний (HEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Мінівен" ]),
            2003),
        new VehicleModel(
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

        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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
        new VehicleModel(
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
        
        new VehicleModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "3 Series",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал", "Кабріолет" ]),
            1975
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "5 Series",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1972
        ),
        new VehicleModel(
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
        new VehicleModel(
            brands.Single(b => b.Name.Equals("BMW")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "X5",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            1999),
        new VehicleModel(
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

        new VehicleModel(
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
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "E-Class",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Універсал", "Кабріолет" ]),
            1953
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Mercedes-Benz")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "S-Class",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Передній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Купе", "Кабріолет" ]),
            1972
        ),
        new VehicleModel(
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
        new VehicleModel(
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
        
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A6",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1994),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A4",
            GetItemsWithParticularValues(engineTypes, [ "Електро", "Гібридний (PHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]), 1994),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "A8",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Універсал" ]),
            1994),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Audi")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "R8",
            GetItemsWithParticularValues(engineTypes,
                [ "Бензиновий" ]),
            GetItemsWithParticularValues(transmissionTypes, [ "Варіатор" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Повний" ]),
            GetItemsWithParticularValues(bodyTypes, [ "Купе" ]),
            2006),
        
        #endregion

        #region Hyundai

        new VehicleModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Elantra",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ "Робот" ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан", "Хетчбек", "Універсал" ]),
            1990
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Sonata",
            GetItemsWithParticularValues(engineTypes, [ "Електро" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Седан" ]),
            1985
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Tucson",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2004
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Santa Fe",
            GetItemsWithParticularValues(engineTypes,
                [ "Електро", "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(transmissionTypes, [ ], true),
            GetItemsWithParticularValues(drivetrainTypes, [ ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2000
        ),
        new VehicleModel(
            brands.Single(b => b.Name.Equals("Hyundai")).Id,
            vehicleTypes.Single(t => t.Name.Equals("Легковик")).Id,
            "Kona",
            GetItemsWithParticularValues(engineTypes,
                [ "Гібридний (PHEV)", "Гібридний (MHEV)" ], true),
            GetItemsWithParticularValues(
                transmissionTypes, [ "Механіка", "Автомат", "Варіатор" ]),
            GetItemsWithParticularValues(drivetrainTypes, [ "Задній" ], true),
            GetItemsWithParticularValues(bodyTypes, [ "Кросовер" ]),
            2017
        )

        #endregion
    ];

    private static List<T> GetItemsWithParticularValues<T>(
        IEnumerable<T> collection,
        IEnumerable<string> nameValues,
        bool skipMode = false) where T : NamedAspect =>
        skipMode
            ? collection.Where(item => !nameValues.Contains(item.Name)).ToList()
            : collection.Where(item => nameValues.Contains(item.Name)).ToList();
}
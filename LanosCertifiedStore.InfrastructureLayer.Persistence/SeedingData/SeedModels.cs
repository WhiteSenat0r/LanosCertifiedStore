namespace Persistence.SeedingData;

internal static class SeedModels
{
    // TODO
    // public static List<VehicleModelDataModel> GetModels(List<VehicleBrandDataModel> brands,
    //     List<VehicleTypeDataModel> types) =>
    // [
    //     #region Toyota
    //
    //     new VehicleModelDataModel(brands[0].Id, "Camry",
    //     [
    //         types[0], // Седан
    //         types[3]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Corolla",
    //     [
    //         types[1], // Хетчбек
    //         types[6]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Rav4",
    //     [
    //         types[4], // Кросовер
    //         types[5]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Highlander",
    //     [
    //         types[4], // Кросовер
    //         types[6]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Prius",
    //         [types[12]]),
    //     new VehicleModelDataModel(brands[0].Id, "Tacoma",
    //         [types[8]]),
    //     new VehicleModelDataModel(brands[0].Id, "Sienna",
    //         [types[7]]),
    //     new VehicleModelDataModel(brands[0].Id, "4Runner",
    //     [
    //         types[6], // Позашляховик
    //         types[9]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Land Cruiser",
    //     [
    //         types[6], // Позашляховик
    //         types[11]
    //     ]),
    //     new VehicleModelDataModel(brands[0].Id, "Yaris",
    //     [
    //         types[0], // Седан
    //         types[1]
    //     ]),
    //
    //     #endregion
    //
    //     #region Ford
    //
    //     new VehicleModelDataModel(brands[1].Id, "F-150",
    //         [types[8]]),
    //     new VehicleModelDataModel(brands[1].Id, "Escape",
    //     [
    //         types[6], // Позашляховик
    //         types[13]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Explorer",
    //     [
    //         types[4], // Кросовер
    //         types[6]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Mustang",
    //         [types[2]]),
    //     new VehicleModelDataModel(brands[1].Id, "Focus",
    //     [
    //         types[1], // Хетчбек
    //         types[14]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Edge",
    //     [
    //         types[4], // Кросовер
    //         types[5]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Fusion",
    //     [
    //         types[0], // Седан
    //         types[14]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Expedition",
    //     [
    //         types[6], // Позашляховик
    //         types[9]
    //     ]),
    //     new VehicleModelDataModel(brands[1].Id, "Ranger",
    //         [types[8]]),
    //     new VehicleModelDataModel(brands[1].Id, "Bronco",
    //     [
    //         types[6], // Позашляховик
    //         types[16]
    //     ]),
    //
    //     #endregion
    //
    //     #region Honda
    //
    //     new VehicleModelDataModel(brands[2].Id, "Civic",
    //     [
    //         types[0], // Седан
    //         types[1], // Хетчбек
    //         types[2], // Купе
    //         types[12], // Компактвен
    //         types[14] // Електромобіль
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Accord",
    //     [
    //         types[0], // Седан
    //         types[2], // Купе
    //         types[12], // Компактвен
    //         types[14] // Електромобіль
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "CR-V",
    //     [
    //         types[4], // Кросовер
    //         types[6] // Позашляховик
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Pilot",
    //     [
    //         types[4], // Кросовер
    //         types[6], // Позашляховик
    //         types[9] // Лімузин
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Odyssey",
    //     [
    //         types[11], // Мінівен
    //         types[9] // Лімузин
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Fit",
    //     [
    //         types[1], // Хетчбек
    //         types[12] // Компактвен
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Ridgeline",
    //     [
    //         types[8] // Пікап
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "HR-V",
    //     [
    //         types[4] // Кросовер
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Insight",
    //     [
    //         types[14] // Електромобіль
    //     ]),
    //     new VehicleModelDataModel(brands[2].Id, "Clarity",
    //     [
    //         types[14] // Електромобіль
    //     ]),
    //
    //     #endregion
    //
    //     #region Chervolet
    //
    //     new VehicleModelDataModel(brands[3].Id, "Silverado",
    //         [types[8]]),
    //     new VehicleModelDataModel(brands[3].Id, "Malibu",
    //     [
    //         types[0], // Седан
    //         types[12]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Equinox",
    //     [
    //         types[4], // Кросовер
    //         types[6]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Camaro",
    //     [
    //         types[2], // Купе
    //         types[5]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Traverse",
    //     [
    //         types[4], // Кросовер
    //         types[6]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Tahoe",
    //     [
    //         types[6], // Позашляховик
    //         types[9]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Suburban",
    //     [
    //         types[6], // Позашляховик
    //         types[9]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Impala",
    //     [
    //         types[0], // Седан
    //         types[9]
    //     ]),
    //     new VehicleModelDataModel(brands[3].Id, "Spark",
    //         [types[11]]),
    //     new VehicleModelDataModel(brands[3].Id, "Bolt",
    //         [types[14]]),
    //
    //     #endregion
    //
    //     #region Volkswagen
    //
    //     new VehicleModelDataModel(brands[4].Id, "Jetta",
    //     [
    //         types[0], // Седан
    //         types[1] // Хетчбек
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Passat",
    //     [
    //         types[0] // Седан
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Golf",
    //     [
    //         types[1] // Хетчбек
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Tiguan",
    //     [
    //         types[4] // Кросовер
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Atlas",
    //     [
    //         types[4], // Кросовер
    //         types[6] // Позашляховик
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Arteon",
    //     [
    //         types[2] // Купе
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "ID.4",
    //     [
    //         types[4], // Кросовер
    //         types[14] // Електромобіль
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Golf GTI",
    //     [
    //         types[1] // Хетчбек
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "Touareg",
    //     [
    //         types[4], // Кросовер
    //         types[6] // Позашляховик
    //     ]),
    //     new VehicleModelDataModel(brands[4].Id, "CC",
    //     [
    //         types[0], // Седан
    //         types[2] // Купе
    //     ]),
    //
    //     #endregion
    //
    //     #region Nissan
    //     new VehicleModelDataModel(brands[5].Id, "Altima", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[5].Id, "Maxima", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[5].Id, "Sentra", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[5].Id, "Rogue", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[5].Id, "Murano", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[5].Id, "Pathfinder", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[5].Id, "Armada", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[5].Id, "Titan", [types[16]]),
    //     // Вантажівка
    //
    //     new VehicleModelDataModel(brands[5].Id, "Versa", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[5].Id, "Leaf", [types[14]]),
    //     // Електромобіль
    //
    //     #endregion
    //
    //     #region BMW
    //     
    //     new VehicleModelDataModel(brands[6].Id, "3 Series", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[6].Id, "5 Series", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[6].Id, "X3", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[6].Id, "X5", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[6].Id, "7 Series", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[6].Id, "X1", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[6].Id, "i3", [types[14]]),
    //     // Електромобіль
    //
    //     new VehicleModelDataModel(brands[6].Id, "M3", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[6].Id, "Z4", [types[16]]),
    //     // Конвертібл
    //
    //     new VehicleModelDataModel(brands[6].Id, "X7", [types[4], types[6]]),
    //     // Кросовер, Позашляховикозашляховик
    //
    //     #endregion
    //
    //     #region Mercedes-Benz
    //
    //     new VehicleModelDataModel(brands[7].Id, "C-Class", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[7].Id, "E-Class", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[7].Id, "S-Class", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[7].Id, "GLC", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[7].Id, "GLE", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[7].Id, "GLS", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[7].Id, "A-Class", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[7].Id, "CLA", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[7].Id, "CLS", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[7].Id, "AMG GT", [types[5]]),
    //     // Спорткар
    //
    //     #endregion
    //
    //     #region Audi
    //     
    //     new VehicleModelDataModel(brands[8].Id, "A3", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[8].Id, "A4", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[8].Id, "A6", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[8].Id, "Q3", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[8].Id, "Q5", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[8].Id, "Q7", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[8].Id, "Q8", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[8].Id, "TT", [types[2], types[16]]),
    //     // Купе, Конвертібл
    //
    //     new VehicleModelDataModel(brands[8].Id, "R8", [types[5]]),
    //     // Спорткар
    //
    //     new VehicleModelDataModel(brands[8].Id, "S5", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     #endregion
    //
    //     #region Hyundai
    //    
    //     new VehicleModelDataModel(brands[9].Id, "Elantra", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[9].Id, "Sonata", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[9].Id, "Tucson", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[9].Id, "Santa Fe", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[9].Id, "Kona", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[9].Id, "Palisade", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[9].Id, "Venue", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[9].Id, "Nexo", [types[14]]),
    //     // Електромобіль
    //
    //     new VehicleModelDataModel(brands[9].Id, "Veloster", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[9].Id, "IONIQ", [types[14], types[15]]),
    //     // Електромобіль, Гібрид
    //
    //     #endregion
    //
    //     #region Kia
    //
    //     new VehicleModelDataModel(brands[10].Id, "Forte", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[10].Id, "Optima", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[10].Id, "Sorento", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[10].Id, "Sportage", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[10].Id, "Soul", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[10].Id, "Telluride", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[10].Id, "Stinger", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[10].Id, "Cadenza", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[10].Id, "Rio", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[10].Id, "K900", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     #endregion
    //
    //     #region Mazda
    //
    //     new VehicleModelDataModel(brands[11].Id, "Mazda3", [types[1], types[2]]),
    //     // Хетчбек, Купе
    //
    //     new VehicleModelDataModel(brands[11].Id, "Mazda6", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[11].Id, "CX-3", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[11].Id, "CX-5", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[11].Id, "CX-9", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[11].Id, "MX-5 Miata", [types[16]]),
    //     // Конвертібл
    //
    //     new VehicleModelDataModel(brands[11].Id, "RX-8", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[11].Id, "Mazda2", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[11].Id, "MX-30", [types[14]]),
    //     // Електромобіль
    //
    //     new VehicleModelDataModel(brands[11].Id, "Mazda5", [types[9]]),
    //     // Мінівен
    //
    //     #endregion
    //
    //     #region Subaru
    //    
    //     new VehicleModelDataModel(brands[12].Id, "Outback", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[12].Id, "Forester", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[12].Id, "Impreza", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[12].Id, "Legacy", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[12].Id, "Crosstrek", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[12].Id, "WRX", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[12].Id, "BRZ", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[12].Id, "Ascent", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[12].Id, "Baja", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[12].Id, "SVX", [types[2]]),
    //     // Купе
    //
    //     #endregion
    //
    //     #region Lexus
    //
    //     new VehicleModelDataModel(brands[13].Id, "ES", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[13].Id, "RX", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[13].Id, "IS", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[13].Id, "NX", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[13].Id, "GX", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[13].Id, "LS", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[13].Id, "LX", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[13].Id, "LC", [types[2], types[16]]),
    //     // Купе, Конвертібл
    //
    //     new VehicleModelDataModel(brands[13].Id, "RC", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[13].Id, "UX", [types[1]]),
    //     // Хетчбек
    //
    //     #endregion
    //
    //     #region Jeep
    //
    //     new VehicleModelDataModel(brands[14].Id, "Wrangler", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[14].Id, "Grand Cherokee", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[14].Id, "Cherokee", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[14].Id, "Renegade", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[14].Id, "Compass", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[14].Id, "Gladiator", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[14].Id, "Wagoneer", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[14].Id, "Commander", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[14].Id, "Patriot", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[14].Id, "Liberty", [types[4]]),
    //     // Кросовер
    //
    //     #endregion
    //
    //     #region Tesla
    //
    //     new VehicleModelDataModel(brands[15].Id, "Model 3", [types[0], types[14]]),
    //     // Седан, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Model S", [types[0], types[14]]),
    //     // Седан, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Model X", [types[6], types[14]]),
    //     // Позашляховик, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Model Y", [types[4], types[14]]),
    //     // Кросовер, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Roadster", [types[2], types[14]]),
    //     // Купе, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Cybertruck", [types[6], types[14]]),
    //     // Позашляховик, Електромобіль
    //
    //     new VehicleModelDataModel(brands[15].Id, "Semi", [types[16]]),
    //     // Вантажівка
    //
    //     #endregion
    //
    //     #region Volvo
    //
    //     new VehicleModelDataModel(brands[16].Id, "S60", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[16].Id, "S90", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[16].Id, "V60", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[16].Id, "V90", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[16].Id, "XC40", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[16].Id, "XC60", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[16].Id, "XC70", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[16].Id, "XC90", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[16].Id, "C30", [types[1]]),
    //     // Хетчбек
    //
    //     new VehicleModelDataModel(brands[16].Id, "C70", [types[2], types[15]]),
    //     // Купе, Гібрид
    //
    //     #endregion
    //
    //     #region Porsche
    //
    //     new VehicleModelDataModel(brands[17].Id, "911", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[17].Id, "Cayenne", [types[6]]),
    //     // Позашляховик
    //
    //     new VehicleModelDataModel(brands[17].Id, "Panamera", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[17].Id, "Macan", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[17].Id, "Boxster", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[17].Id, "Cayman", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[17].Id, "Taycan", [types[0], types[14]]),
    //     // Седан, Електромобіль
    //
    //     new VehicleModelDataModel(brands[17].Id, "718", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[17].Id, "911 GT3", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[17].Id, "918 Spyder", [types[2], types[16]]),
    //     // Купе, Конвертібл
    //
    //     #endregion
    //
    //     #region Ferrari
    //
    //     new VehicleModelDataModel(brands[18].Id, "488 GTB", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[18].Id, "F8 Tributo", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[18].Id, "812 Superfast", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[18].Id, "Portofino", [types[2], types[15]]),
    //     // Купе, Гібрид
    //
    //     new VehicleModelDataModel(brands[18].Id, "Roma", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[18].Id, "SF90 Stradale", [types[2], types[14]]),
    //     // Купе, Електромобіль
    //
    //     new VehicleModelDataModel(brands[18].Id, "GTC4Lusso", [types[2], types[6]]),
    //     // Купе, Позашляховик
    //
    //     new VehicleModelDataModel(brands[18].Id, "458 Italia", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[18].Id, "LaFerrari", [types[2], types[16]]),
    //     // Купе, Конвертібл
    //
    //     new VehicleModelDataModel(brands[18].Id, "Enzo", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     #endregion
    //
    //     #region Jaguar
    //
    //     new VehicleModelDataModel(brands[19].Id, "XE", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[19].Id, "XF", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[19].Id, "XJ", [types[0], types[2]]),
    //     // Седан, Купе
    //
    //     new VehicleModelDataModel(brands[19].Id, "F-Pace", [types[4], types[6]]),
    //     // Кросовер, Позашляховик
    //
    //     new VehicleModelDataModel(brands[19].Id, "E-Pace", [types[4]]),
    //     // Кросовер
    //
    //     new VehicleModelDataModel(brands[19].Id, "I-Pace", [types[4], types[14]]),
    //     // Кросовер, Електромобіль
    //
    //     new VehicleModelDataModel(brands[19].Id, "F-Type", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[19].Id, "XK", [types[2]]),
    //     // Купе
    //
    //     new VehicleModelDataModel(brands[19].Id, "C-Type", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     new VehicleModelDataModel(brands[19].Id, "D-Type", [types[2], types[5]]),
    //     // Купе, Спорткар
    //
    //     #endregion
    // ];
}
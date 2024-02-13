using Persistence.DataModels;

namespace Persistence.SeedingData;

internal static class SeedModels
{
    public static List<VehicleModelDataModel> GetModels(List<VehicleBrandDataModel> brands) =>
    [
        // Toyota
        new VehicleModelDataModel(brands[0].Id, "Camry"),
        new VehicleModelDataModel(brands[0].Id, "Corolla"),
        new VehicleModelDataModel(brands[0].Id, "Rav4"),
        new VehicleModelDataModel(brands[0].Id, "Highlander"),
        new VehicleModelDataModel(brands[0].Id, "Prius"),
        new VehicleModelDataModel(brands[0].Id, "Tacoma"),
        new VehicleModelDataModel(brands[0].Id, "Sienna"),
        new VehicleModelDataModel(brands[0].Id, "4Runner"),
        new VehicleModelDataModel(brands[0].Id, "Land Cruiser"),
        new VehicleModelDataModel(brands[0].Id, "Yaris"),

        // Ford
        new VehicleModelDataModel(brands[1].Id, "F-150"),
        new VehicleModelDataModel(brands[1].Id, "Escape"),
        new VehicleModelDataModel(brands[1].Id, "Explorer"),
        new VehicleModelDataModel(brands[1].Id, "Mustang"),
        new VehicleModelDataModel(brands[1].Id, "Focus"),
        new VehicleModelDataModel(brands[1].Id, "Edge"),
        new VehicleModelDataModel(brands[1].Id, "Fusion"),
        new VehicleModelDataModel(brands[1].Id, "Expedition"),
        new VehicleModelDataModel(brands[1].Id, "Ranger"),
        new VehicleModelDataModel(brands[1].Id, "Bronco"),

        // Honda
        new VehicleModelDataModel(brands[2].Id, "Civic"),
        new VehicleModelDataModel(brands[2].Id, "Accord"),
        new VehicleModelDataModel(brands[2].Id, "CR-V"),
        new VehicleModelDataModel(brands[2].Id, "Pilot"),
        new VehicleModelDataModel(brands[2].Id, "Odyssey"),
        new VehicleModelDataModel(brands[2].Id, "Fit"),
        new VehicleModelDataModel(brands[2].Id, "Ridgeline"),
        new VehicleModelDataModel(brands[2].Id, "HR-V"),
        new VehicleModelDataModel(brands[2].Id, "Insight"),
        new VehicleModelDataModel(brands[2].Id, "Clarity"),

        // Chevrolet
        new VehicleModelDataModel(brands[3].Id, "Silverado"),
        new VehicleModelDataModel(brands[3].Id, "Malibu"),
        new VehicleModelDataModel(brands[3].Id, "Equinox"),
        new VehicleModelDataModel(brands[3].Id, "Camaro"),
        new VehicleModelDataModel(brands[3].Id, "Traverse"),
        new VehicleModelDataModel(brands[3].Id, "Tahoe"),
        new VehicleModelDataModel(brands[3].Id, "Suburban"),
        new VehicleModelDataModel(brands[3].Id, "Impala"),
        new VehicleModelDataModel(brands[3].Id, "Spark"),
        new VehicleModelDataModel(brands[3].Id, "Bolt"),

        // Volkswagen
        new VehicleModelDataModel(brands[4].Id, "Jetta"),
        new VehicleModelDataModel(brands[4].Id, "Passat"),
        new VehicleModelDataModel(brands[4].Id, "Golf"),
        new VehicleModelDataModel(brands[4].Id, "Tiguan"),
        new VehicleModelDataModel(brands[4].Id, "Atlas"),
        new VehicleModelDataModel(brands[4].Id, "Arteon"),
        new VehicleModelDataModel(brands[4].Id, "ID.4"),
        new VehicleModelDataModel(brands[4].Id, "Golf GTI"),
        new VehicleModelDataModel(brands[4].Id, "Touareg"),
        new VehicleModelDataModel(brands[4].Id, "CC"),

        // Nissan
        new VehicleModelDataModel(brands[5].Id, "Altima"),
        new VehicleModelDataModel(brands[5].Id, "Maxima"),
        new VehicleModelDataModel(brands[5].Id, "Sentra"),
        new VehicleModelDataModel(brands[5].Id, "Rogue"),
        new VehicleModelDataModel(brands[5].Id, "Murano"),
        new VehicleModelDataModel(brands[5].Id, "Pathfinder"),
        new VehicleModelDataModel(brands[5].Id, "Armada"),
        new VehicleModelDataModel(brands[5].Id, "Titan"),
        new VehicleModelDataModel(brands[5].Id, "Versa"),
        new VehicleModelDataModel(brands[5].Id, "Leaf"),

        // BMW
        new VehicleModelDataModel(brands[6].Id, "3 Series"),
        new VehicleModelDataModel(brands[6].Id, "5 Series"),
        new VehicleModelDataModel(brands[6].Id, "X3"),
        new VehicleModelDataModel(brands[6].Id, "X5"),
        new VehicleModelDataModel(brands[6].Id, "7 Series"),
        new VehicleModelDataModel(brands[6].Id, "X1"),
        new VehicleModelDataModel(brands[6].Id, "i3"),
        new VehicleModelDataModel(brands[6].Id, "M3"),
        new VehicleModelDataModel(brands[6].Id, "Z4"),
        new VehicleModelDataModel(brands[6].Id, "X7"),

        // Mercedes-Benz
        new VehicleModelDataModel(brands[7].Id, "C-Class"),
        new VehicleModelDataModel(brands[7].Id, "E-Class"),
        new VehicleModelDataModel(brands[7].Id, "S-Class"),
        new VehicleModelDataModel(brands[7].Id, "GLC"),
        new VehicleModelDataModel(brands[7].Id, "GLE"),
        new VehicleModelDataModel(brands[7].Id, "GLS"),
        new VehicleModelDataModel(brands[7].Id, "A-Class"),
        new VehicleModelDataModel(brands[7].Id, "CLA"),
        new VehicleModelDataModel(brands[7].Id, "CLS"),
        new VehicleModelDataModel(brands[7].Id, "AMG GT"),

        // Audi
        new VehicleModelDataModel(brands[8].Id, "A3"),
        new VehicleModelDataModel(brands[8].Id, "A4"),
        new VehicleModelDataModel(brands[8].Id, "A6"),
        new VehicleModelDataModel(brands[8].Id, "Q3"),
        new VehicleModelDataModel(brands[8].Id, "Q5"),
        new VehicleModelDataModel(brands[8].Id, "Q7"),
        new VehicleModelDataModel(brands[8].Id, "Q8"),
        new VehicleModelDataModel(brands[8].Id, "TT"),
        new VehicleModelDataModel(brands[8].Id, "R8"),
        new VehicleModelDataModel(brands[8].Id, "S5"),

        // Hyundai
        new VehicleModelDataModel(brands[9].Id, "Elantra"),
        new VehicleModelDataModel(brands[9].Id, "Sonata"),
        new VehicleModelDataModel(brands[9].Id, "Tucson"),
        new VehicleModelDataModel(brands[9].Id, "Santa Fe"),
        new VehicleModelDataModel(brands[9].Id, "Kona"),
        new VehicleModelDataModel(brands[9].Id, "Palisade"),
        new VehicleModelDataModel(brands[9].Id, "Venue"),
        new VehicleModelDataModel(brands[9].Id, "Nexo"),
        new VehicleModelDataModel(brands[9].Id, "Veloster"),
        new VehicleModelDataModel(brands[9].Id, "IONIQ"),

        // Kia
        new VehicleModelDataModel(brands[10].Id, "Forte"),
        new VehicleModelDataModel(brands[10].Id, "Optima"),
        new VehicleModelDataModel(brands[10].Id, "Sorento"),
        new VehicleModelDataModel(brands[10].Id, "Sportage"),
        new VehicleModelDataModel(brands[10].Id, "Soul"),
        new VehicleModelDataModel(brands[10].Id, "Telluride"),
        new VehicleModelDataModel(brands[10].Id, "Stinger"),
        new VehicleModelDataModel(brands[10].Id, "Cadenza"),
        new VehicleModelDataModel(brands[10].Id, "Rio"),
        new VehicleModelDataModel(brands[10].Id, "K900"),

        // Mazda
        new VehicleModelDataModel(brands[11].Id, "Mazda3"),
        new VehicleModelDataModel(brands[11].Id, "Mazda6"),
        new VehicleModelDataModel(brands[11].Id, "CX-3"),
        new VehicleModelDataModel(brands[11].Id, "CX-5"),
        new VehicleModelDataModel(brands[11].Id, "CX-9"),
        new VehicleModelDataModel(brands[11].Id, "MX-5 Miata"),
        new VehicleModelDataModel(brands[11].Id, "RX-8"),
        new VehicleModelDataModel(brands[11].Id, "Mazda2"),
        new VehicleModelDataModel(brands[11].Id, "MX-30"),
        new VehicleModelDataModel(brands[11].Id, "Mazda5"),

        // Subaru
        new VehicleModelDataModel(brands[12].Id, "Outback"),
        new VehicleModelDataModel(brands[12].Id, "Forester"),
        new VehicleModelDataModel(brands[12].Id, "Impreza"),
        new VehicleModelDataModel(brands[12].Id, "Legacy"),
        new VehicleModelDataModel(brands[12].Id, "Crosstrek"),
        new VehicleModelDataModel(brands[12].Id, "WRX"),
        new VehicleModelDataModel(brands[12].Id, "BRZ"),
        new VehicleModelDataModel(brands[12].Id, "Ascent"),
        new VehicleModelDataModel(brands[12].Id, "Baja"),
        new VehicleModelDataModel(brands[12].Id, "SVX"),

        // Lexus
        new VehicleModelDataModel(brands[13].Id, "ES"),
        new VehicleModelDataModel(brands[13].Id, "RX"),
        new VehicleModelDataModel(brands[13].Id, "IS"),
        new VehicleModelDataModel(brands[13].Id, "NX"),
        new VehicleModelDataModel(brands[13].Id, "GX"),
        new VehicleModelDataModel(brands[13].Id, "LS"),
        new VehicleModelDataModel(brands[13].Id, "LX"),
        new VehicleModelDataModel(brands[13].Id, "LC"),
        new VehicleModelDataModel(brands[13].Id, "RC"),
        new VehicleModelDataModel(brands[13].Id, "UX"),

        // Jeep
        new VehicleModelDataModel(brands[14].Id, "Wrangler"),
        new VehicleModelDataModel(brands[14].Id, "Grand Cherokee"),
        new VehicleModelDataModel(brands[14].Id, "Cherokee"),
        new VehicleModelDataModel(brands[14].Id, "Renegade"),
        new VehicleModelDataModel(brands[14].Id, "Compass"),
        new VehicleModelDataModel(brands[14].Id, "Gladiator"),
        new VehicleModelDataModel(brands[14].Id, "Wagoneer"),
        new VehicleModelDataModel(brands[14].Id, "Commander"),
        new VehicleModelDataModel(brands[14].Id, "Patriot"),
        new VehicleModelDataModel(brands[14].Id, "Liberty"),

        // Tesla
        new VehicleModelDataModel(brands[15].Id, "Model 3"),
        new VehicleModelDataModel(brands[15].Id, "Model S"),
        new VehicleModelDataModel(brands[15].Id, "Model X"),
        new VehicleModelDataModel(brands[15].Id, "Model Y"),
        new VehicleModelDataModel(brands[15].Id, "Roadster"),
        new VehicleModelDataModel(brands[15].Id, "Cybertruck"),
        new VehicleModelDataModel(brands[15].Id, "Semi"),

        // Volvo
        new VehicleModelDataModel(brands[16].Id, "S60"),
        new VehicleModelDataModel(brands[16].Id, "S90"),
        new VehicleModelDataModel(brands[16].Id, "V60"),
        new VehicleModelDataModel(brands[16].Id, "V90"),
        new VehicleModelDataModel(brands[16].Id, "XC40"),
        new VehicleModelDataModel(brands[16].Id, "XC60"),
        new VehicleModelDataModel(brands[16].Id, "XC70"),
        new VehicleModelDataModel(brands[16].Id, "XC90"),
        new VehicleModelDataModel(brands[16].Id, "C30"),
        new VehicleModelDataModel(brands[16].Id, "C70"),

        // Porsche
        new VehicleModelDataModel(brands[17].Id, "911"),
        new VehicleModelDataModel(brands[17].Id, "Cayenne"),
        new VehicleModelDataModel(brands[17].Id, "Panamera"),
        new VehicleModelDataModel(brands[17].Id, "Macan"),
        new VehicleModelDataModel(brands[17].Id, "Boxster"),
        new VehicleModelDataModel(brands[17].Id, "Cayman"),
        new VehicleModelDataModel(brands[17].Id, "Taycan"),
        new VehicleModelDataModel(brands[17].Id, "718"),
        new VehicleModelDataModel(brands[17].Id, "911 GT3"),
        new VehicleModelDataModel(brands[17].Id, "918 Spyder"),

        // Ferrari
        new VehicleModelDataModel(brands[18].Id, "488 GTB"),
        new VehicleModelDataModel(brands[18].Id, "F8 Tributo"),
        new VehicleModelDataModel(brands[18].Id, "812 Superfast"),
        new VehicleModelDataModel(brands[18].Id, "Portofino"),
        new VehicleModelDataModel(brands[18].Id, "Roma"),
        new VehicleModelDataModel(brands[18].Id, "SF90 Stradale"),
        new VehicleModelDataModel(brands[18].Id, "GTC4Lusso"),
        new VehicleModelDataModel(brands[18].Id, "458 Italia"),
        new VehicleModelDataModel(brands[18].Id, "LaFerrari"),
        new VehicleModelDataModel(brands[18].Id, "Enzo"),

        // Jaguar
        new VehicleModelDataModel(brands[19].Id, "XE"),
        new VehicleModelDataModel(brands[19].Id, "XF"),
        new VehicleModelDataModel(brands[19].Id, "XJ"),
        new VehicleModelDataModel(brands[19].Id, "F-Pace"),
        new VehicleModelDataModel(brands[19].Id, "E-Pace"),
        new VehicleModelDataModel(brands[19].Id, "I-Pace"),
        new VehicleModelDataModel(brands[19].Id, "F-Type"),
        new VehicleModelDataModel(brands[19].Id, "XK"),
        new VehicleModelDataModel(brands[19].Id, "C-Type"),
        new VehicleModelDataModel(brands[19].Id, "D-Type")
    ];
}
using Domain.Entities.VehicleRelated.Classes;

namespace Persistence.SeedingData;

internal static class SeedModels
{
    public static List<VehicleModel> GetModels(List<VehicleBrand> brands) =>
    [
        // Toyota
        new VehicleModel(brands[0].Id, "Camry"),
        new VehicleModel(brands[0].Id, "Corolla"),
        new VehicleModel(brands[0].Id, "Rav4"),
        new VehicleModel(brands[0].Id, "Highlander"),
        new VehicleModel(brands[0].Id, "Prius"),
        new VehicleModel(brands[0].Id, "Tacoma"),
        new VehicleModel(brands[0].Id, "Sienna"),
        new VehicleModel(brands[0].Id, "4Runner"),
        new VehicleModel(brands[0].Id, "Land Cruiser"),
        new VehicleModel(brands[0].Id, "Yaris"),

        // Ford
        new VehicleModel(brands[1].Id, "F-150"),
        new VehicleModel(brands[1].Id, "Escape"),
        new VehicleModel(brands[1].Id, "Explorer"),
        new VehicleModel(brands[1].Id, "Mustang"),
        new VehicleModel(brands[1].Id, "Focus"),
        new VehicleModel(brands[1].Id, "Edge"),
        new VehicleModel(brands[1].Id, "Fusion"),
        new VehicleModel(brands[1].Id, "Expedition"),
        new VehicleModel(brands[1].Id, "Ranger"),
        new VehicleModel(brands[1].Id, "Bronco"),

        // Honda
        new VehicleModel(brands[2].Id, "Civic"),
        new VehicleModel(brands[2].Id, "Accord"),
        new VehicleModel(brands[2].Id, "CR-V"),
        new VehicleModel(brands[2].Id, "Pilot"),
        new VehicleModel(brands[2].Id, "Odyssey"),
        new VehicleModel(brands[2].Id, "Fit"),
        new VehicleModel(brands[2].Id, "Ridgeline"),
        new VehicleModel(brands[2].Id, "HR-V"),
        new VehicleModel(brands[2].Id, "Insight"),
        new VehicleModel(brands[2].Id, "Clarity"),

        // Chevrolet
        new VehicleModel(brands[3].Id, "Silverado"),
        new VehicleModel(brands[3].Id, "Malibu"),
        new VehicleModel(brands[3].Id, "Equinox"),
        new VehicleModel(brands[3].Id, "Camaro"),
        new VehicleModel(brands[3].Id, "Traverse"),
        new VehicleModel(brands[3].Id, "Tahoe"),
        new VehicleModel(brands[3].Id, "Suburban"),
        new VehicleModel(brands[3].Id, "Impala"),
        new VehicleModel(brands[3].Id, "Spark"),
        new VehicleModel(brands[3].Id, "Bolt"),

        // Volkswagen
        new VehicleModel(brands[4].Id, "Jetta"),
        new VehicleModel(brands[4].Id, "Passat"),
        new VehicleModel(brands[4].Id, "Golf"),
        new VehicleModel(brands[4].Id, "Tiguan"),
        new VehicleModel(brands[4].Id, "Atlas"),
        new VehicleModel(brands[4].Id, "Arteon"),
        new VehicleModel(brands[4].Id, "ID.4"),
        new VehicleModel(brands[4].Id, "Golf GTI"),
        new VehicleModel(brands[4].Id, "Touareg"),
        new VehicleModel(brands[4].Id, "CC"),

        // Nissan
        new VehicleModel(brands[5].Id, "Altima"),
        new VehicleModel(brands[5].Id, "Maxima"),
        new VehicleModel(brands[5].Id, "Sentra"),
        new VehicleModel(brands[5].Id, "Rogue"),
        new VehicleModel(brands[5].Id, "Murano"),
        new VehicleModel(brands[5].Id, "Pathfinder"),
        new VehicleModel(brands[5].Id, "Armada"),
        new VehicleModel(brands[5].Id, "Titan"),
        new VehicleModel(brands[5].Id, "Versa"),
        new VehicleModel(brands[5].Id, "Leaf"),

        // BMW
        new VehicleModel(brands[6].Id, "3 Series"),
        new VehicleModel(brands[6].Id, "5 Series"),
        new VehicleModel(brands[6].Id, "X3"),
        new VehicleModel(brands[6].Id, "X5"),
        new VehicleModel(brands[6].Id, "7 Series"),
        new VehicleModel(brands[6].Id, "X1"),
        new VehicleModel(brands[6].Id, "i3"),
        new VehicleModel(brands[6].Id, "M3"),
        new VehicleModel(brands[6].Id, "Z4"),
        new VehicleModel(brands[6].Id, "X7"),

        // Mercedes-Benz
        new VehicleModel(brands[7].Id, "C-Class"),
        new VehicleModel(brands[7].Id, "E-Class"),
        new VehicleModel(brands[7].Id, "S-Class"),
        new VehicleModel(brands[7].Id, "GLC"),
        new VehicleModel(brands[7].Id, "GLE"),
        new VehicleModel(brands[7].Id, "GLS"),
        new VehicleModel(brands[7].Id, "A-Class"),
        new VehicleModel(brands[7].Id, "CLA"),
        new VehicleModel(brands[7].Id, "CLS"),
        new VehicleModel(brands[7].Id, "AMG GT"),

        // Audi
        new VehicleModel(brands[8].Id, "A3"),
        new VehicleModel(brands[8].Id, "A4"),
        new VehicleModel(brands[8].Id, "A6"),
        new VehicleModel(brands[8].Id, "Q3"),
        new VehicleModel(brands[8].Id, "Q5"),
        new VehicleModel(brands[8].Id, "Q7"),
        new VehicleModel(brands[8].Id, "Q8"),
        new VehicleModel(brands[8].Id, "TT"),
        new VehicleModel(brands[8].Id, "R8"),
        new VehicleModel(brands[8].Id, "S5"),

        // Hyundai
        new VehicleModel(brands[9].Id, "Elantra"),
        new VehicleModel(brands[9].Id, "Sonata"),
        new VehicleModel(brands[9].Id, "Tucson"),
        new VehicleModel(brands[9].Id, "Santa Fe"),
        new VehicleModel(brands[9].Id, "Kona"),
        new VehicleModel(brands[9].Id, "Palisade"),
        new VehicleModel(brands[9].Id, "Venue"),
        new VehicleModel(brands[9].Id, "Nexo"),
        new VehicleModel(brands[9].Id, "Veloster"),
        new VehicleModel(brands[9].Id, "IONIQ"),

        // Kia
        new VehicleModel(brands[10].Id, "Forte"),
        new VehicleModel(brands[10].Id, "Optima"),
        new VehicleModel(brands[10].Id, "Sorento"),
        new VehicleModel(brands[10].Id, "Sportage"),
        new VehicleModel(brands[10].Id, "Soul"),
        new VehicleModel(brands[10].Id, "Telluride"),
        new VehicleModel(brands[10].Id, "Stinger"),
        new VehicleModel(brands[10].Id, "Cadenza"),
        new VehicleModel(brands[10].Id, "Rio"),
        new VehicleModel(brands[10].Id, "K900"),

        // Mazda
        new VehicleModel(brands[11].Id, "Mazda3"),
        new VehicleModel(brands[11].Id, "Mazda6"),
        new VehicleModel(brands[11].Id, "CX-3"),
        new VehicleModel(brands[11].Id, "CX-5"),
        new VehicleModel(brands[11].Id, "CX-9"),
        new VehicleModel(brands[11].Id, "MX-5 Miata"),
        new VehicleModel(brands[11].Id, "RX-8"),
        new VehicleModel(brands[11].Id, "Mazda2"),
        new VehicleModel(brands[11].Id, "MX-30"),
        new VehicleModel(brands[11].Id, "Mazda5"),

        // Subaru
        new VehicleModel(brands[12].Id, "Outback"),
        new VehicleModel(brands[12].Id, "Forester"),
        new VehicleModel(brands[12].Id, "Impreza"),
        new VehicleModel(brands[12].Id, "Legacy"),
        new VehicleModel(brands[12].Id, "Crosstrek"),
        new VehicleModel(brands[12].Id, "WRX"),
        new VehicleModel(brands[12].Id, "BRZ"),
        new VehicleModel(brands[12].Id, "Ascent"),
        new VehicleModel(brands[12].Id, "Baja"),
        new VehicleModel(brands[12].Id, "SVX"),

        // Lexus
        new VehicleModel(brands[13].Id, "ES"),
        new VehicleModel(brands[13].Id, "RX"),
        new VehicleModel(brands[13].Id, "IS"),
        new VehicleModel(brands[13].Id, "NX"),
        new VehicleModel(brands[13].Id, "GX"),
        new VehicleModel(brands[13].Id, "LS"),
        new VehicleModel(brands[13].Id, "LX"),
        new VehicleModel(brands[13].Id, "LC"),
        new VehicleModel(brands[13].Id, "RC"),
        new VehicleModel(brands[13].Id, "UX"),

        // Jeep
        new VehicleModel(brands[14].Id, "Wrangler"),
        new VehicleModel(brands[14].Id, "Grand Cherokee"),
        new VehicleModel(brands[14].Id, "Cherokee"),
        new VehicleModel(brands[14].Id, "Renegade"),
        new VehicleModel(brands[14].Id, "Compass"),
        new VehicleModel(brands[14].Id, "Gladiator"),
        new VehicleModel(brands[14].Id, "Wagoneer"),
        new VehicleModel(brands[14].Id, "Commander"),
        new VehicleModel(brands[14].Id, "Patriot"),
        new VehicleModel(brands[14].Id, "Liberty"),

        // Tesla
        new VehicleModel(brands[15].Id, "Model 3"),
        new VehicleModel(brands[15].Id, "Model S"),
        new VehicleModel(brands[15].Id, "Model X"),
        new VehicleModel(brands[15].Id, "Model Y"),
        new VehicleModel(brands[15].Id, "Roadster"),
        new VehicleModel(brands[15].Id, "Cybertruck"),
        new VehicleModel(brands[15].Id, "Semi"),

        // Volvo
        new VehicleModel(brands[16].Id, "S60"),
        new VehicleModel(brands[16].Id, "S90"),
        new VehicleModel(brands[16].Id, "V60"),
        new VehicleModel(brands[16].Id, "V90"),
        new VehicleModel(brands[16].Id, "XC40"),
        new VehicleModel(brands[16].Id, "XC60"),
        new VehicleModel(brands[16].Id, "XC70"),
        new VehicleModel(brands[16].Id, "XC90"),
        new VehicleModel(brands[16].Id, "C30"),
        new VehicleModel(brands[16].Id, "C70"),

        // Porsche
        new VehicleModel(brands[17].Id, "911"),
        new VehicleModel(brands[17].Id, "Cayenne"),
        new VehicleModel(brands[17].Id, "Panamera"),
        new VehicleModel(brands[17].Id, "Macan"),
        new VehicleModel(brands[17].Id, "Boxster"),
        new VehicleModel(brands[17].Id, "Cayman"),
        new VehicleModel(brands[17].Id, "Taycan"),
        new VehicleModel(brands[17].Id, "718"),
        new VehicleModel(brands[17].Id, "911 GT3"),
        new VehicleModel(brands[17].Id, "918 Spyder"),

        // Ferrari
        new VehicleModel(brands[18].Id, "488 GTB"),
        new VehicleModel(brands[18].Id, "F8 Tributo"),
        new VehicleModel(brands[18].Id, "812 Superfast"),
        new VehicleModel(brands[18].Id, "Portofino"),
        new VehicleModel(brands[18].Id, "Roma"),
        new VehicleModel(brands[18].Id, "SF90 Stradale"),
        new VehicleModel(brands[18].Id, "GTC4Lusso"),
        new VehicleModel(brands[18].Id, "458 Italia"),
        new VehicleModel(brands[18].Id, "LaFerrari"),
        new VehicleModel(brands[18].Id, "Enzo"),

        // Jaguar
        new VehicleModel(brands[19].Id, "XE"),
        new VehicleModel(brands[19].Id, "XF"),
        new VehicleModel(brands[19].Id, "XJ"),
        new VehicleModel(brands[19].Id, "F-Pace"),
        new VehicleModel(brands[19].Id, "E-Pace"),
        new VehicleModel(brands[19].Id, "I-Pace"),
        new VehicleModel(brands[19].Id, "F-Type"),
        new VehicleModel(brands[19].Id, "XK"),
        new VehicleModel(brands[19].Id, "C-Type"),
        new VehicleModel(brands[19].Id, "D-Type")
    ];
}
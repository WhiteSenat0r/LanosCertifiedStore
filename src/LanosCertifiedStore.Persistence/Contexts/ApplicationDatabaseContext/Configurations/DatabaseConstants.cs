namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal static class DatabaseConstants
{
    internal static class Schemas
    {
        public const string IdentitySchema = "identity";
        public const string LocationsSchema = "locations";
        public const string VehiclesSchema = "vehicles";
    }

    internal static class Tables
    {
        public const string Vehicles = "Vehicles";
        public const string VehicleBrands = "VehicleBrands";
        public const string VehicleColors = "VehicleColors";
        public const string VehicleImages = "VehicleImages";
        public const string VehicleModels = "VehicleModels";
        public const string VehiclePrices = "VehiclePrices";
        public const string VehicleTypes = "VehicleTypes";
        public const string VehicleBodyTypes = "VehicleBodyTypes";
        public const string VehicleDrivetrainTypes = "VehicleDrivetrainTypes";
        public const string VehicleEngineTypes = "VehicleEngineTypes";
        public const string VehicleTransmissionTypes = "VehicleTransmissionTypes";
        public const string VehicleLocationAreas = "VehicleLocationAreas";
        public const string VehicleLocationRegions = "VehicleLocationRegions";
        public const string VehicleLocationTowns = "VehicleLocationTowns";
        public const string VehicleLocationTownTypes = "VehicleLocationTownTypes";
        public const string Permissions = "Permissions";
        public const string RolePermissions = "RolePermissions";
        public const string Users = "Users";
        public const string UserRoles = "UserRoles";
    }
}
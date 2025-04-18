namespace LanosCertifiedStore.Application.Vehicles;

internal static class VehicleValidatorMessages
{
    public const string InvalidDescription = "Description must be greater than 20 characters and less than 3000!";
    public const string InvalidPrice = "Price must be greater than 0 $USD!";
    public const string InvalidDisplacement = "Engine's displacement must be greater than 0 liters!";
    public const string InvalidMileage = "Mileage must be greater or equal to 0 km!";
    public const string ModelRequired = "Model must be present!";
    public const string BrandRequired = "Brand must be present!";
    public const string VinRequired = "VIN-code must be present!";
    public const string InvalidVinLength = "VIN-code must be 17 symbols long!";
    public const string BodyTypeRequired = "Type must be present!";
    public const string EngineTypeRequired = "Engine type must be present!";
    public const string TransmissionTypeRequired = "Transmission type must be present!";
    public const string DrivetrainTypeRequired = "Drivetrain type must be present!";
    public const string ColorRequired = "Color must be present!";
    public const string TownRequired = "Town must be present!";
    public const string VehicleRequired = "Vehicle must be selected!";
}
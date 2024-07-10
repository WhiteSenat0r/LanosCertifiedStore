namespace Application.VehicleModels;

internal static class VehicleModelValidatorMessages
{
    public const string InvalidNameValue = "Name must be greater than 2 characters and less than 64!";
    public const string AlreadyExistingNameValue = "Vehicle brand with such name already exists!";
    public const string InvalidMinimalProductionYearValue = "Minimal production year must be greater or equal 1900!";
    public const string InvalidBrandIdValue = "Brand with such ID does not exist!";
    public const string InvalidTypeIdValue = "Type with such ID does not exist!";
    public const string TooBigMinimalProductionYearValue = "Minimal production year must not be greater than maximum one!";
    public const string TooSmallMaximumProductionYearValue = "Maximum production year must not be lesser than minimum one!";
}
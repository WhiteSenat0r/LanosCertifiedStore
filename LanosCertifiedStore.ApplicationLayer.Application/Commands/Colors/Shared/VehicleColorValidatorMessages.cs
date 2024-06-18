using Domain.Constants.VehicleRelated;

namespace Application.Commands.Colors.Shared;

public static class VehicleColorValidatorMessages
{
    public static readonly string InvalidNameValue = 
        $"Name must be greater than {VehicleColorConstants.MinimalNameLength} characters" +
        $" and less than {VehicleColorConstants.MaximumNameLength}";
    public const string InvalidHexValue = "Hex value must satisfy a color hex pattern (e. g. #000000, #FFFFFF)!";
    public const string AlreadyExistingNameValue = "Vehicle color with such name already exists!";
}
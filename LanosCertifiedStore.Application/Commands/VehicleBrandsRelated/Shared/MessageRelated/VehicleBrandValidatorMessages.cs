using Domain.Constants.VehicleRelated;

namespace Application.Commands.VehicleBrandsRelated.Shared.MessageRelated;

public static class VehicleBrandValidatorMessages
{
    public static readonly string InvalidNameValue = 
        $"Name must be greater than {VehicleBrandConstants.MinimalNameLength} characters" +
        $" and less than {VehicleBrandConstants.MaximumNameLength}";
    public const string AlreadyExistingNameValue = "Vehicle brand with such name already exists!";
}
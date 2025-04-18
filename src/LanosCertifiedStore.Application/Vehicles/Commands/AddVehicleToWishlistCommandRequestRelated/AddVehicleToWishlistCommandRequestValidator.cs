using FluentValidation;

namespace LanosCertifiedStore.Application.Vehicles.Commands.AddVehicleToWishlistCommandRequestRelated;

internal sealed class AddVehicleToWishlistCommandRequestValidator : 
    AbstractValidator<AddVehicleToWishlistCommandRequest>
{
    public AddVehicleToWishlistCommandRequestValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotEqual(Guid.Empty)
            .WithMessage(VehicleValidatorMessages.VehicleRequired);
    }
}
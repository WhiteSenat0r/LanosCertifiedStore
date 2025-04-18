using FluentValidation;

namespace LanosCertifiedStore.Application.Vehicles.Commands.RemoveVehicleFromWishlistCommandRequestRelated;

internal sealed class RemoveVehicleFromWishlistCommandRequestValidator : 
    AbstractValidator<RemoveVehicleFromWishlistCommandRequest>
{
    public RemoveVehicleFromWishlistCommandRequestValidator()
    {
        RuleFor(x => x.VehicleId)
            .NotEqual(Guid.Empty)
            .WithMessage(VehicleValidatorMessages.VehicleRequired);
    }
}
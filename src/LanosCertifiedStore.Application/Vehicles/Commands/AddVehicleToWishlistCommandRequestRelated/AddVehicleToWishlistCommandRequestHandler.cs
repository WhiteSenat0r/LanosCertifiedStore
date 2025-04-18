using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.AddVehicleToWishlistCommandRequestRelated;

internal sealed class AddVehicleToWishlistCommandRequestHandler(
    IVehicleService vehicleService,
    IUserContext userContext) : IRequestHandler<AddVehicleToWishlistCommandRequest, Result>
{
    public async Task<Result> Handle(AddVehicleToWishlistCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var requestingUserId = userContext.UserId;

            await vehicleService.AddVehicleToWishlist(request.VehicleId, requestingUserId, cancellationToken);
            
            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException)
        {
            return Result.Create(Error.NotFound(request.VehicleId));
        }
    }
}
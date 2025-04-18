using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.RemoveVehicleFromWishlistCommandRequestRelated;

internal sealed class RemoveVehicleFromWishlistCommandRequestHandler(
    IVehicleService vehicleService,
    IUserContext userContext) : IRequestHandler<RemoveVehicleFromWishlistCommandRequest, Result>
{
    public async Task<Result> Handle(RemoveVehicleFromWishlistCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var requestingUserId = userContext.UserId;

            await vehicleService.RemoveVehicleFromWishlist(request.VehicleId, requestingUserId, cancellationToken);
            
            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException)
        {
            return Result.Create(Error.NotFound(request.VehicleId));
        }
    }
}
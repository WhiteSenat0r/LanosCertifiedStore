using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Users.Queries.VehiclesRelated.GetUserVehiclesQueryRequestRelated;

internal sealed class GetUserVehiclesQueryRequestHandler(IUserContext userContext, IVehicleService vehicleService) :
    IRequestHandler<GetUserVehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        GetUserVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        (request.FilteringParameters as IVehicleFilteringRequestParameters)!.UserId = userContext.UserId;
        
        var wishlistVehicles = await vehicleService.GetUserVehicles(request, cancellationToken);

        var wishlistPresentStatuses =
            await vehicleService.GetVehiclesWishlistPresenceStatuses(
                wishlistVehicles.Select(v => v.Id).ToList(),
                userContext.UserId,
                cancellationToken);
            
        foreach (var vehicle in wishlistVehicles)
        {
            vehicle.IsPresentInWishlist = wishlistPresentStatuses[vehicle.Id];
        }
        
        return Result<PaginationResult<VehicleDto>>.Success(
            new PaginationResult<VehicleDto>(wishlistVehicles, request.FilteringParameters.PageIndex));
    }
}
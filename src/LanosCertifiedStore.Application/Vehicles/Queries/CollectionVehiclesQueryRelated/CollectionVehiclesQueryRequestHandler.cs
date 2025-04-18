using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Queries.CollectionVehiclesQueryRelated;

internal sealed class CollectionVehiclesQueryRequestHandler(
    IVehicleService vehicleService,
    IUserContext userContext) :
    IRequestHandler<CollectionVehiclesQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        CollectionVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var vehicles = await vehicleService.GetVehicles(request, cancellationToken);

        if (userContext.IsAuthenticated)
        {
            var wishlistPresentStatuses =
                await vehicleService.GetVehiclesWishlistPresenceStatuses(
                    vehicles.Select(v => v.Id).ToList(),
                    userContext.UserId,
                    cancellationToken);
            
            foreach (var vehicle in vehicles)
            {
                vehicle.IsPresentInWishlist = wishlistPresentStatuses[vehicle.Id];
            }
        }
        
        var paginationResult = new PaginationResult<VehicleDto>(vehicles, request.FilteringParameters.PageIndex);

        return paginationResult;
    }
}
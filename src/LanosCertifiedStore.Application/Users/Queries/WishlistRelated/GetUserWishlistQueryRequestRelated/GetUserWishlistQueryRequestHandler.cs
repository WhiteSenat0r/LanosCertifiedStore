using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using MediatR;

namespace LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;

internal sealed class GetUserWishlistQueryRequestHandler(IUserContext userContext, IUserService userService) :
    IRequestHandler<GetUserWishlistQueryRequest, Result<PaginationResult<VehicleDto>>>
{
    public async Task<Result<PaginationResult<VehicleDto>>> Handle(
        GetUserWishlistQueryRequest request,
        CancellationToken cancellationToken)
    {
        (request.FilteringParameters as IUserWishlistFilteringRequestParameters)!.UserId = userContext.UserId;
        
        var wishlistVehicles = await userService.GetUserWishlist(request, cancellationToken);

        return Result<PaginationResult<VehicleDto>>.Success(
            new PaginationResult<VehicleDto>(wishlistVehicles, request.FilteringParameters.PageIndex));
    }
}
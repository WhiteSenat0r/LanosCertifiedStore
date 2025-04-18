using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Users.Queries.WishlistRelated.CountUserWishlistVehiclesQueryRequestRelated;

internal sealed class CountUserWishlistVehiclesQueryRequestHandler(IUserContext userContext, IUserService userService) :
    IRequestHandler<CountUserWishlistVehiclesQueryRequest, Result<ItemsCountDto>>
{
    public async Task<Result<ItemsCountDto>> Handle(
        CountUserWishlistVehiclesQueryRequest request,
        CancellationToken cancellationToken)
    {
        (request.FilteringParameters as IUserWishlistFilteringRequestParameters)!.UserId = userContext.UserId;
        
        var wishlistVehiclesCount = await userService.GetWishlistItemsCount(request, cancellationToken);

        return Result<ItemsCountDto>.Success(wishlistVehiclesCount);
    }
}
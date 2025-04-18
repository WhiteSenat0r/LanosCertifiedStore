using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;

public sealed record GetUserWishlistQueryRequest(IFilteringRequestParameters<UserWishlist> FilteringParameters)
    : ICollectionQueryRequest<UserWishlist, PaginationResult<VehicleDto>, VehicleDto>;
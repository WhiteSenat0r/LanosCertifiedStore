using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.CountUserWishlistVehiclesQueryRequestRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace LanosCertifiedStore.Application.Users;

public interface IUserService
{
    Task AddAsync(User user, UserWishlist userWishlist, CancellationToken cancellationToken = default);
    Task ChangeUserRole(Guid userId, UserRole role, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<VehicleDto>> GetUserWishlist(GetUserWishlistQueryRequest request, CancellationToken cancellationToken = default);
    Task<ItemsCountDto> GetWishlistItemsCount(CountUserWishlistVehiclesQueryRequest request, CancellationToken cancellationToken = default);
}
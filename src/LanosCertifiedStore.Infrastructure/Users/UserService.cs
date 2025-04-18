using LanosCertifiedStore.Application.Shared.DtosRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.CountUserWishlistVehiclesQueryRequestRelated;
using LanosCertifiedStore.Application.Users.Queries.WishlistRelated.GetUserWishlistQueryRequestRelated;
using LanosCertifiedStore.Application.Vehicles.Dtos;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.UsersRelated;
using LanosCertifiedStore.Persistence.Queries.UserRelated;

namespace LanosCertifiedStore.Infrastructure.Users;

internal sealed class UserService(
    AddUserCommand addUserCommand,
    ChangeUserRoleCommand changeUserRoleCommand,
    SaveChangesCommand saveChangesCommand,
    GetUserWishlistQuery getUserWishlistQuery,
    CountUserWishlistVehiclesQuery countUserWishlistVehiclesQuery) : IUserService
{
    public async Task AddAsync(User user, UserWishlist userWishlist, CancellationToken cancellationToken = default)
    {
        await addUserCommand.Execute(user, userWishlist);
        await saveChangesCommand.Execute(cancellationToken);
    }

    public async Task ChangeUserRole(Guid userId, UserRole role, CancellationToken cancellationToken = default)
    {
        await changeUserRoleCommand.Execute(userId, role);
        await saveChangesCommand.Execute(cancellationToken);
    }

    public async Task<IReadOnlyCollection<VehicleDto>> GetUserWishlist(
        GetUserWishlistQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await getUserWishlistQuery.Execute(request, cancellationToken);
    }

    public async Task<ItemsCountDto> GetWishlistItemsCount(CountUserWishlistVehiclesQueryRequest request,
        CancellationToken cancellationToken = default)
    {
        return await countUserWishlistVehiclesQuery.Execute(request, cancellationToken);
    }
}
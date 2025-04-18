using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;

internal sealed class AddUserFromProviderCommandRequestHandler(IUserService userService)
    : IRequestHandler<AddUserFromProviderCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        AddUserFromProviderCommandRequest request, CancellationToken cancellationToken)
    {
        var userWishlist = new UserWishlist(request.UserId);
        var user = new User(request.UserId)
        {
            WishlistId = userWishlist.Id
        };
        
        await userService.AddAsync(user, userWishlist, cancellationToken);

        return user.Id;
    }
}
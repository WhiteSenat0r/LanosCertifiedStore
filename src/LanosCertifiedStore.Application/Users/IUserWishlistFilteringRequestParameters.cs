using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace LanosCertifiedStore.Application.Users;

public interface IUserWishlistFilteringRequestParameters : IFilteringRequestParameters<UserWishlist>
{
    public Guid UserId { get; set; }
};
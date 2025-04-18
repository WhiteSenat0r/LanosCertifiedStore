using LanosCertifiedStore.Application.Shared.RequestParamsRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Application.Users;

public class UserWishlistFilteringRequestParameters : BaseFilteringRequestParameters<Vehicle>,
    IUserWishlistFilteringRequestParameters
{
    public Guid UserId { get; set; }
}
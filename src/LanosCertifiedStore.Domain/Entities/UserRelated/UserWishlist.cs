using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Domain.Entities.UserRelated;

public sealed class UserWishlist : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public UserWishlist()
    {
    }

    public UserWishlist(Guid userId)
    {
        UserId = userId;
    }
}
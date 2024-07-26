using LanosCertifiedStore.Domain.Contracts.Common;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;

namespace LanosCertifiedStore.Domain.Entities.UserRelated;

public sealed class User : IIdentifiable<Guid>
{
    public Guid Id { get; set; } 
    public UserRole UserRole { get; init; }
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public User()
    {
    }

    public User(Guid id)
    {
        Id = id;
        UserRole = UserRole.User;
    }
}
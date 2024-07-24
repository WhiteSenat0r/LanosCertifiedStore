using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated;

namespace Domain.Entities.UserRelated;

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
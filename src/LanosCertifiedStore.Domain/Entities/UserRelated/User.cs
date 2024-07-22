using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated;

namespace Domain.Entities.UserRelated;

public sealed class User : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string IdentityId { get; set; } = null!;
    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public User() { }

    public User(
        string email,
        string firstName,
        string lastName,
        string phoneNumber,
        string identityId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IdentityId = identityId;
    }
}
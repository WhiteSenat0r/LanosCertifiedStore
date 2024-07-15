using Domain.Entities.VehicleRelated;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserRelated;

public sealed class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; } = [];

    public User() { }

    public User(
        string email,
        string firstName,
        string lastName,
        string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = email;
        PhoneNumber = phoneNumber;
    }
}
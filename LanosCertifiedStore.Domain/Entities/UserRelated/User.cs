using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;
using Domain.Entities.VehicleRelated;

namespace Domain.Entities.UserRelated;

public sealed class User : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    [EmailAddress(ErrorMessage = "Property must be of email type!")]
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public ICollection<UserRole> Roles { get; set; } = [];
    // TODO Implement relationship later
    // public ICollection<Vehicle> Vehicles { get; set; } = [];

    public User() { }

    public User(string firstName, string lastName, string email, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }
}
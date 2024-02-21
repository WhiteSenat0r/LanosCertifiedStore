using Domain.Contracts.Common;

namespace Domain.Entities.VehicleRelated.Classes;

public sealed class User : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public ICollection<string> Roles { get; set; } = default!;

    public User()
    {
    }

    public User(string firstName, string lastName, string email, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }

    public User(string firstName, string lastName, string email, ICollection<string> roles)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Roles = roles;
    }
}
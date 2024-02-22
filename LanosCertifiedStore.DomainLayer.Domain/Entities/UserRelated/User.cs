using Domain.Contracts.Common;

namespace Domain.Entities.UserRelated;

public sealed class User : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string PasswordHash { get; init; } = default!;
    public ICollection<string> Roles { get; init; } = default!;

    public User() { }

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
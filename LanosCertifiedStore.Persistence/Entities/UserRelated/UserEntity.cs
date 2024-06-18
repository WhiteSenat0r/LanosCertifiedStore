using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;
using Persistence.Entities.VehicleRelated;

namespace Persistence.Entities.UserRelated;

internal sealed class UserEntity : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    [EmailAddress(ErrorMessage = "Property must be of email type!")]
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public ICollection<UserRoleEntity> Roles { get; set; } = new List<UserRoleEntity>();
    public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

    public UserEntity() { }

    public UserEntity(string firstName, string lastName, string email, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }
}
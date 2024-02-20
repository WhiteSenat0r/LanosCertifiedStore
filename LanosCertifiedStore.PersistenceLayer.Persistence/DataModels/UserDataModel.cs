using System.ComponentModel.DataAnnotations;
using Domain.Contracts.Common;

namespace Persistence.DataModels;

internal sealed class UserDataModel : IEntity<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    [EmailAddress(ErrorMessage = "Property must be of email type!")]
    public string Email { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;
    public ICollection<UserRoleDataModel> Roles { get; set; } = new List<UserRoleDataModel>();
    public ICollection<VehicleDataModel> Vehicles { get; set; } = new List<VehicleDataModel>();

    public UserDataModel()
    {
    }

    public UserDataModel(string firstName, string lastName, string email, string passwordHash)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
    }
}
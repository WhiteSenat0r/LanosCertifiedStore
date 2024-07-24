using System.Collections;
using Domain.Entities.Common.Classes;

namespace Domain.Entities.UserRelated;

public sealed class UserRole
{
    public static readonly UserRole Administrator = new("Administrator");
    public static readonly UserRole Manager = new("Manager");
    public static readonly UserRole User = new("User");

    public UserRole()
    {
    }

    public UserRole(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public ICollection<User> Users { get; init; } = [];
    public override string ToString() => Name;
}
using Domain.Entities.Common.Classes;

namespace Domain.Entities.UserRelated;

public sealed class UserRole : NamedAspect
{
    public ICollection<User> Users { get; set; } = [];

    public UserRole() { }

    public UserRole(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => Name;
}
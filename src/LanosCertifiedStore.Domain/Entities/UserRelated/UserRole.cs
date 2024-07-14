using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.UserRelated;

public class UserRole : IdentityRole<Guid>
{
    public ICollection<User> Users { get; set; } = [];

    public UserRole()
    {
    }

    public UserRole(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => Name;
}
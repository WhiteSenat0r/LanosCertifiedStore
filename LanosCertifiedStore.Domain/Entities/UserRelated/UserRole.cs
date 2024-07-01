using Domain.Contracts.Common;

namespace Domain.Entities.UserRelated;

public class UserRole : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public ICollection<User> Users { get; set; } = [];
    
    public UserRole() { }

    public UserRole(string name) => Name = name;

    public override string ToString() => Name;
}
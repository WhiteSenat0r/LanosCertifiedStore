using Domain.Contracts.Common;

namespace Persistence.Entities.UserRelated;

internal class UserRoleEntity : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = default!;
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    
    public UserRoleEntity() { }

    public UserRoleEntity(string name) => Name = name;

    public override string ToString() => Name;
}
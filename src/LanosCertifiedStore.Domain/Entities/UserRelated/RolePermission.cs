namespace Domain.Entities.UserRelated;

public sealed class RolePermission
{
    public UserRole UserRole { get; init; }
    public string UserRoleName { get; init; }
    public Permission Permission { get; init; }
    public string PermissionCode { get; init; }
}
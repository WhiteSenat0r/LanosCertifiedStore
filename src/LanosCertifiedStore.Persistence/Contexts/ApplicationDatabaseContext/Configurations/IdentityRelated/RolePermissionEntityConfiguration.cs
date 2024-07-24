using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class RolePermissionEntityConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions", DatabaseSchemas.IdentitySchema);

        builder.HasKey(rp => new { rp.PermissionCode, rp.UserRoleName });

        builder.HasData(
            // User
            CreateRolePermission(UserRole.User, Permission.GetUser),
            CreateRolePermission(UserRole.User, Permission.CreateVehicles),
            // Manager
            CreateRolePermission(UserRole.Manager, Permission.GetUser),
            CreateRolePermission(UserRole.Manager, Permission.ListUsers),
            CreateRolePermission(UserRole.Manager, Permission.CreateUser),
            CreateRolePermission(UserRole.Manager, Permission.UpdateUser),
            CreateRolePermission(UserRole.Manager, Permission.DeleteUser),
            CreateRolePermission(UserRole.Manager, Permission.CreateVehicles),
            CreateRolePermission(UserRole.Manager, Permission.UpdateVehicles),
            CreateRolePermission(UserRole.Manager, Permission.CreateBrands),
            CreateRolePermission(UserRole.Manager, Permission.UpdateBrands),
            CreateRolePermission(UserRole.Manager, Permission.CreateModel),
            CreateRolePermission(UserRole.Manager, Permission.UpdateModel),
            // Administrator
            CreateRolePermission(UserRole.Administrator, Permission.GetUser),
            CreateRolePermission(UserRole.Administrator, Permission.ListUsers),
            CreateRolePermission(UserRole.Administrator, Permission.CreateUser),
            CreateRolePermission(UserRole.Administrator, Permission.UpdateUser),
            CreateRolePermission(UserRole.Administrator, Permission.ChangeUserRole),
            CreateRolePermission(UserRole.Administrator, Permission.DeleteUser),
            CreateRolePermission(UserRole.Administrator, Permission.CreateVehicles),
            CreateRolePermission(UserRole.Administrator, Permission.UpdateVehicles),
            CreateRolePermission(UserRole.Administrator, Permission.CreateBrands),
            CreateRolePermission(UserRole.Administrator, Permission.UpdateBrands),
            CreateRolePermission(UserRole.Administrator, Permission.CreateModel),
            CreateRolePermission(UserRole.Administrator, Permission.UpdateModel)
        );
    }

    private static RolePermission CreateRolePermission(UserRole role, Permission permission)
    {
        return new RolePermission
        {
            UserRoleName = role.Name,
            PermissionCode = permission.Code
        };
    }
}
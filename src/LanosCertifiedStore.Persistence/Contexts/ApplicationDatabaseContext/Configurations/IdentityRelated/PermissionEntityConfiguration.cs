using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permissions", DatabaseSchemas.IdentitySchema);

        builder.HasKey(p => p.Code);

        builder.Property(p => p.Code).HasMaxLength(64);

        builder.HasData(
            Permission.GetUser,
            Permission.ListUsers,
            Permission.CreateUser,
            Permission.UpdateUser,
            Permission.ChangeUserRole,
            Permission.CreateVehicles,
            Permission.UpdateVehicles,
            Permission.DeleteVehicles,
            Permission.CreateBrands,
            Permission.UpdateBrands,
            Permission.CreateModel,
            Permission.UpdateModel
        );
    }
}
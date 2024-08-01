using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Name);
        
        builder.Property(x => x.Name).HasMaxLength(64);
        
        builder.HasData(UserRole.User, UserRole.Manager, UserRole.Administrator);
        builder.ToTable("UserRoles", DatabaseSchemas.IdentitySchema);
    }
}
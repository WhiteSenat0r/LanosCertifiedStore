using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        var roles = new List<UserRole>
        {
            new("User"),
            new("Administrator")
        };
        
        builder.HasData(roles);
    }
}
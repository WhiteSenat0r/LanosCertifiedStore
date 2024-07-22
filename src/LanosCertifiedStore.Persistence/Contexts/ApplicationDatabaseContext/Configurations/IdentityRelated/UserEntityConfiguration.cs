using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(32);

        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.ToTable("Users", DatabaseSchemas.IdentitySchema);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.UserRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class UserDataModelConfiguration : IEntityTypeConfiguration<UserDataModel>
{
    public void Configure(EntityTypeBuilder<UserDataModel> builder)
    {
        builder.HasIndex(x => x.Email).IsUnique();
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(32);
        
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder.HasMany(m => m.Roles)
            .WithMany(r => r.Users)
            .UsingEntity(join => join.ToTable("UserRoles"));
    }
}
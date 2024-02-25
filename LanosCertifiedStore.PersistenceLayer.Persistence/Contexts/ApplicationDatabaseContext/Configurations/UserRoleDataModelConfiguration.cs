using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataModels.UserRelated;

namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations;

internal sealed class UserRoleDataModelConfiguration : IEntityTypeConfiguration<UserRoleDataModel>
{
    public void Configure(EntityTypeBuilder<UserRoleDataModel> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

        var roles = new List<UserRoleDataModel>
        {
            new("User"),
            new("Administrator"),
        };

        builder.HasData(roles);
    }
}
using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

internal sealed class UserWishlistEntityConfiguration : IEntityTypeConfiguration<UserWishlist>
{
    public void Configure(EntityTypeBuilder<UserWishlist> builder)
    {
        builder
            .HasOne(w => w.User)
            .WithOne(u => u.Wishlist)
            .HasForeignKey<UserWishlist>(w => w.UserId);
        
        builder
            .HasMany(w => w.Vehicles)
            .WithMany(v => v.Wishlists)
            .UsingEntity(join =>
                join.ToTable(DatabaseConstants.Tables.VehiclesWishlists, DatabaseConstants.Schemas.VehiclesSchema)
            );
        
        builder.ToTable(DatabaseConstants.Tables.UserWishlists, DatabaseConstants.Schemas.IdentitySchema);
    }
}
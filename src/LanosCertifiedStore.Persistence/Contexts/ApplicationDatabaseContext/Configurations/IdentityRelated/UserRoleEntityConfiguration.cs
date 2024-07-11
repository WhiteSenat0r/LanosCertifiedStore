namespace Persistence.Contexts.ApplicationDatabaseContext.Configurations.IdentityRelated;

// TODO
// internal sealed class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
// {
//     public void Configure(EntityTypeBuilder<UserRole> builder)
//     {
//         builder.HasIndex(x => x.Name).IsUnique();
//
//         builder.Property(x => x.Name)
//             .IsRequired()
//             .HasMaxLength(64);
//
//         var roles = new List<UserRole>
//         {
//             new("Користувач"),
//             new("Адміністратор")
//         };
//         
//         builder.HasData(roles);
//         builder.ToTable("UserRoles");
//     }
// }
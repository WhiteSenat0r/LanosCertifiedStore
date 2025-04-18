using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.Persistence.Commands.UsersRelated;

public sealed class AddUserCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(User user, UserWishlist userWishlist)
    {
        await context.AddAsync(user);
        await context.AddAsync(userWishlist);
        context.Attach(user.UserRole);
    }
}
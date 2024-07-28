using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.Persistence.Commands.UsersRelated;

public sealed class ChangeUserRoleCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(Guid userId, UserRole role)
    {
        var user = await context
            .Set<User>()
            .FindAsync(userId);

        if (user is null)
        {
            throw new KeyNotFoundException();
        }

        context.Attach(role);
        user.UserRole = role;
    }
}
using Domain.Entities.UserRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.UsersRelated;

public sealed class AddUserCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(User user)
    {
        foreach (var role in user.Roles)
        {
            context.Attach(role);
        }

        await context.AddAsync(user);
    }
}
using Domain.Entities.UserRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Commands.UsersRelated;

public sealed class AddUserCommand(ApplicationDatabaseContext context)
{
    public async Task Execute(User user)
    {
        await context.AddAsync(user);
    }
}
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.UsersRelated;

namespace LanosCertifiedStore.Infrastructure.Services.Users;

internal sealed class UserService(
    AddUserCommand addUserCommand,
    SaveChangesCommand saveChangesCommand) : IUserService
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await addUserCommand.Execute(user);
        await saveChangesCommand.Execute(cancellationToken);
    }
}
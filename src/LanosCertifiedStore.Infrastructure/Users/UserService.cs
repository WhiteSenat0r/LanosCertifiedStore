using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Commands.Common;
using LanosCertifiedStore.Persistence.Commands.UsersRelated;

namespace LanosCertifiedStore.Infrastructure.Users;

internal sealed class UserService(
    AddUserCommand addUserCommand,
    ChangeUserRoleCommand changeUserRoleCommand,
    SaveChangesCommand saveChangesCommand) : IUserService
{
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await addUserCommand.Execute(user);
        await saveChangesCommand.Execute(cancellationToken);
    }

    public async Task ChangeUserRole(Guid userId, UserRole role, CancellationToken cancellationToken = default)
    {
        await changeUserRoleCommand.Execute(userId, role);
        await saveChangesCommand.Execute(cancellationToken);
    }
}
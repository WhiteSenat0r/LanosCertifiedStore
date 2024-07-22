using Application.Identity;
using Domain.Entities.UserRelated;
using Persistence.Commands.Common;
using Persistence.Commands.UsersRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Users;

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
using Application.Users;
using Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

// TODO Resolve authorization issue
internal sealed class AuthorizationService(ApplicationDatabaseContext context) : IAuthorizationService
{
    public async Task<HashSet<string>> GetUserPermissionsAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await context.Set<User>().Select(u => new User
        {
            Id = u.Id,
            UserRole = u.UserRole
        }).SingleOrDefaultAsync(u => u.Id.Equals(userId), cancellationToken);

        if (user is null)
        {
            return [];
        }

        var permissions = await context.Set<RolePermission>()
            .Where(x => x.UserRoleName.Equals(user.UserRole.Name))
            .Select(x => x.PermissionCode)
            .ToListAsync(cancellationToken);

        return permissions.ToHashSet();
    }
}
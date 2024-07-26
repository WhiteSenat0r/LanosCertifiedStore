using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace LanosCertifiedStore.Infrastructure.Services.Authorization;

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
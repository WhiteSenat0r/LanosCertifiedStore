namespace LanosCertifiedStore.Application.Users;

public interface IAuthorizationService
{
    Task<HashSet<string>> GetUserPermissionsAsync(Guid userId, CancellationToken cancellationToken = default);
}
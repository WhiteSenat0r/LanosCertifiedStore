using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace LanosCertifiedStore.Application.Users;

public interface IUserService
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);
    Task ChangeUserRole(Guid userId, UserRole role, CancellationToken cancellationToken = default);
}
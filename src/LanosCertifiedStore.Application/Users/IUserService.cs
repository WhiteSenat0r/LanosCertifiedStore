using Domain.Entities.UserRelated;

namespace Application.Users;

public interface IUserService
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}
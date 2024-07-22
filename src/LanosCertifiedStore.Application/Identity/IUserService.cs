using Domain.Entities.UserRelated;

namespace Application.Identity;

public interface IUserService
{
    Task AddAsync(User user, CancellationToken cancellationToken = default);
}
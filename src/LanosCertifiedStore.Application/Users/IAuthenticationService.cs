using Domain.Entities.UserRelated;

namespace Application.Users;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(
        User user,
        
        CancellationToken cancellationToken = default);
}
using Domain.Entities.UserRelated;

namespace Application.Identity.ServicesContracts;

public interface IJwtProvider : ITokenProvider<string, User>
{
    string Generate(User user);
}
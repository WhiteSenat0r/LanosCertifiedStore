using Domain.Entities.UserRelated;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IJwtProvider : ITokenProvider<string, User>
{
    string Generate(User user);
}
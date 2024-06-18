using Domain.Models.UserRelated;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IJwtProvider : ITokenProvider<string, User>
{
    string Generate(User user);
}
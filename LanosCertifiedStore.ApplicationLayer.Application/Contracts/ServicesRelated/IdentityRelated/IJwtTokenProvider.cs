using Domain.Entities.UserRelated;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IJwtProvider
{
    string Generate(User user);
}
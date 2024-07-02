using Domain.Entities.IdentityRelated;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IRefreshTokenProvider : ITokenProvider<RefreshToken, int>
{
    RefreshToken Generate(int bytesQuantity);
}
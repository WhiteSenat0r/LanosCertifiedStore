using Domain.Entities.IdentityRelated;

namespace Application.Identity.ServicesContracts;

public interface IRefreshTokenProvider : ITokenProvider<RefreshToken, int>
{
    RefreshToken Generate(int bytesQuantity);
}
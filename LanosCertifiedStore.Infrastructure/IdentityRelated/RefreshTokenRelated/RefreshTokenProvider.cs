using System.Security.Cryptography;
using Application.Contracts.ServicesRelated.IdentityRelated;
using Domain.Models.IdentityRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated.RefreshTokenRelated;

internal sealed class RefreshTokenProvider : IRefreshTokenProvider
{
    public RefreshToken Generate(int bytesQuantity)
    {
        var randomNumberBytes = new byte[bytesQuantity];

        using var randomNumberGenerator = RandomNumberGenerator.Create();
        
        randomNumberGenerator.GetBytes(randomNumberBytes);

        return new RefreshToken
        {
            Value = Convert.ToBase64String(randomNumberBytes)
        };
    }
}
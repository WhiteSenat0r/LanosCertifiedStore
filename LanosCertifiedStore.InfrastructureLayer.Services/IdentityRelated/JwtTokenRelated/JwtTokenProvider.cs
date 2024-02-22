using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.ServicesRelated.IdentityRelated;
using Domain.Entities.UserRelated;
using Microsoft.IdentityModel.Tokens;

namespace LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated.JwtTokenRelated;

internal sealed class JwtTokenProvider(JwtTokenOptions tokenOptions) : IJwtProvider
{
    public string Generate(User user)
    {
        var claims = GetUserClaims(user);
        var signingCredentials = GetSigningCredentials(tokenOptions);

        return GetGeneratedTokenValue(tokenOptions, claims, signingCredentials);;
    }

    private string GetGeneratedTokenValue(
        JwtTokenOptions jwtTokenOptions, 
        IEnumerable<Claim> claims, 
        SigningCredentials signingCredentials)
    {
        var token = new JwtSecurityToken(
            jwtTokenOptions.Issuer,
            jwtTokenOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(5),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);
        
        return tokenValue;
    }

    private SigningCredentials GetSigningCredentials(JwtTokenOptions jwtTokenOptions) =>
        new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtTokenOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

    private IEnumerable<Claim> GetUserClaims(User user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, user.FirstName + user.LastName),
            new(ClaimTypes.Email, user.Email),
        };
        
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

        return claims;
    }
}
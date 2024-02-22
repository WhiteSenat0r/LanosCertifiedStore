using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.ServicesRelated.IdentityRelated;
using Domain.Entities.UserRelated;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated.JwtRelated;

internal sealed class JwtProvider(IConfiguration configuration) : IJwtProvider
{
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, user.FirstName + user.LastName),
            new(ClaimTypes.Email, user.Email),
        };


        var jwtOptions = new JwtOptions()
        {
            Audience = configuration["Audience"]!,
            Issuer = configuration["Issuer"]!,
            SecretKey = configuration["SecretKey"]!
        };

        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddHours(7),
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return tokenValue;
    }
}
using System.Security.Claims;
using Application.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization.Claims;

internal sealed class CustomClaimsTransformation(IServiceProvider serviceProvider) : IClaimsTransformation
{
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal.HasClaim(c => c.Type == CustomClaims.Sub))
        {
            return principal;
        }
        
        using var scope = serviceProvider.CreateScope();

        var authorizationService = scope.ServiceProvider.GetRequiredService<IAuthorizationService>();
        var userId = principal.GetIdClaim();
        var permissions = await authorizationService.GetUserPermissionsAsync(userId);

        if (!permissions.Any())
        {
            throw new ApplicationException("No permissions are available!");
        }

        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(CustomClaims.Sub, userId.ToString()));

        foreach (var permission in permissions)
        {
            claimsIdentity.AddClaim(new Claim(CustomClaims.Permission, permission));
        }
        
        principal.AddIdentity(claimsIdentity);

        return principal;
    }
}
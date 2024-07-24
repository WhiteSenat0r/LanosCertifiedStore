using LanosCertifiedStore.InfrastructureLayer.Services.Authorization.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using IAuthorizationService = Application.Users.IAuthorizationService;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

// TODO Resolve authorization issue
public sealed class PermissionAuthorizationHandler(
    IServiceProvider serviceProvider) : AuthorizationHandler<PermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        if (context.User.Identity is not { IsAuthenticated: true })
        {
            return;
        }

        using var scope = serviceProvider.CreateScope();

        var authorizationService = scope.ServiceProvider.GetRequiredService<IAuthorizationService>();
        
        var userId = context.User.GetIdClaim();
        
        var permissions = await authorizationService.GetUserPermissionsAsync(userId);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
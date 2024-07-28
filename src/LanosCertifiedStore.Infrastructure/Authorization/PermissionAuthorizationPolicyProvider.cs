using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationPolicyProvider(
    IOptions<AuthorizationOptions> options) : DefaultAuthorizationPolicyProvider(options)
{
    private readonly AuthorizationOptions _authorizationOptions = options.Value;

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is not null)
        {
            return policy;
        }

        var permissionPolicy = CreatePermissionPolicy(policyName);
        
        _authorizationOptions.AddPolicy(policyName, permissionPolicy);

        return permissionPolicy;
    }

    private AuthorizationPolicy CreatePermissionPolicy(string policyName)
    {
        return new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();
    }
}
using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

// TODO Resolve authorization issue
public sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission => permission;
}
using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

public sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission => permission;
}
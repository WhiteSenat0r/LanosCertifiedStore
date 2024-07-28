using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.Infrastructure.Authorization;

public sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission => permission;
}
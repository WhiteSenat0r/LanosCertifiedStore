using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

// TODO Resolve authorization issue
public sealed class HasAccessPermissionAttribute(string permission) : AuthorizeAttribute(permission);
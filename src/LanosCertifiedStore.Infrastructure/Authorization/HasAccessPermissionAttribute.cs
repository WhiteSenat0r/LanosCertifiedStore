using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authorization;

public sealed class HasAccessPermissionAttribute(string permission) : AuthorizeAttribute(permission);
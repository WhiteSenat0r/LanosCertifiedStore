using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.Infrastructure.Authorization;

public sealed class HasAccessPermissionAttribute(string permission) : AuthorizeAttribute(permission);
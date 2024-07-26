using Microsoft.AspNetCore.Authorization;

namespace LanosCertifiedStore.Infrastructure.Services.Authorization;

public sealed class HasAccessPermissionAttribute(string permission) : AuthorizeAttribute(permission);
using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Infrastructure.Authorization.Claims;
using Microsoft.AspNetCore.Http;

namespace LanosCertifiedStore.Infrastructure.Authentication;

internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid UserId =>
        httpContextAccessor
            .HttpContext?
            .User
            .GetIdClaim() ??
        throw new ApplicationException("User context is unavailable");

    public bool IsAuthenticated =>
        httpContextAccessor
            .HttpContext?
            .User
            .Identity?
            .IsAuthenticated ??
        throw new ApplicationException("User context is unavailable");
}
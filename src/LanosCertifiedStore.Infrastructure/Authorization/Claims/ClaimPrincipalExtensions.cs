using System.Security.Claims;

namespace LanosCertifiedStore.Infrastructure.Services.Authorization.Claims;

public static class ClaimPrincipalExtensions
{
    public static Guid GetSubClaim(this ClaimsPrincipal? principal)
    {
        var userSubject = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(userSubject, out Guid parsedUserSubject) 
            ? parsedUserSubject 
            : throw new ApplicationException("User's subject is not available!");
    }
    
    public static Guid GetIdClaim(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.TryParse(userId, out Guid parsedUserId) 
            ? parsedUserId 
            : throw new ApplicationException("User's ID is not available!");
    }
}
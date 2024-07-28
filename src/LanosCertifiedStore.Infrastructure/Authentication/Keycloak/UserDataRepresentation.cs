using LanosCertifiedStore.Application.Identity;

namespace LanosCertifiedStore.Infrastructure.Authentication.Keycloak;

internal sealed record UserDataRepresentation(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    Attributes Attributes,
    bool EmailVerified,
    List<FederatedIdentityDto> FederatedIdentities,
    long CreatedTimestamp);

internal sealed record Attributes(List<string> PhoneNumber);
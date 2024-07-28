using LanosCertifiedStore.Application.Identity;

namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed record UserDataRepresentation(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    UserDataAttributes? Attributes,
    bool EmailVerified,
    List<FederatedIdentityDto> FederatedIdentities,
    long CreatedTimestamp);

internal sealed record UserDataAttributes(List<string> PhoneNumber);
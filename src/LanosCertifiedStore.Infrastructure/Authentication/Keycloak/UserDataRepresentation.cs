using LanosCertifiedStore.Application.Identity.Dtos;

namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed record UserDataRepresentation(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    UserDataAttributes? Attributes,
    bool EmailVerified,
    List<FederatedIdentityDto> FederatedIdentities,
    long CreatedTimestamp,
    List<string> RequiredActions);

internal sealed record UserDataAttributes(List<string> PhoneNumber);
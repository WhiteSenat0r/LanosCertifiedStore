namespace LanosCertifiedStore.Application.Identity;

public sealed record UserDataDto(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    bool EmailVerified,
    List<FederatedIdentityDto> FederatedIdentities,
    long CreatedTimestamp);
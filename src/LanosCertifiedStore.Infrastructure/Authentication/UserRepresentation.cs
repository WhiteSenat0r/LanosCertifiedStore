namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication;

internal sealed record UserRepresentation(
    string Username,
    string Email,
    // string PhoneNumber,
    string FirstName,
    string LastName,
    bool EmailVerified,
    bool Enabled,
    CredentialRepresentation[] Credentials);

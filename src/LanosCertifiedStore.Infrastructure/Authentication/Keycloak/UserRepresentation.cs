namespace LanosCertifiedStore.Infrastructure.Authentication.Keycloak;

internal sealed record UserRepresentation(
    string Username,
    string Email,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName);
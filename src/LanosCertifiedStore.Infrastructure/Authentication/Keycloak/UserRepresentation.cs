namespace LanosCertifiedStore.Infrastructure.Services.Authentication.Keycloak;

internal sealed record UserRepresentation(
    string Username,
    string Email,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName);
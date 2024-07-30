namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal record UserRepresentation(
    string Username,
    string Email,
    bool EmailVerified,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName,
    List<string> RequiredActions = null!);
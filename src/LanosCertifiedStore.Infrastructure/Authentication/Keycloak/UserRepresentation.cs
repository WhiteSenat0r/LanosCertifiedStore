namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal record UserRepresentation(
    string Username,
    string Email,
    bool EmailVerified,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName,
    List<string> RequiredActions = null!);


/// <summary>
/// Represents a user with an additional ID and password for registration purposes.
/// </summary>
/// <remarks>
/// This record is used only for integration testing and includes fields for user information and credentials.
/// </remarks>
/// <param name="Id">The unique identifier for the user, which may be null if not set.</param>
/// <param name="Enabled">Specifies whether the user account is enabled.</param>
/// <param name="Credentials">A list of credential representations for the user, such as passwords or other authentication methods.</param>
internal sealed record UserRepresentationWithPasswordAndId(
    Guid Id,
    string Username,
    string Email,
    bool EmailVerified,
    bool Enabled,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName,
    List<CredentialRepresentation> Credentials,
    List<string> RequiredActions = null!)
    : UserRepresentation(Username, Email, EmailVerified, Attributes, FirstName, LastName, RequiredActions);

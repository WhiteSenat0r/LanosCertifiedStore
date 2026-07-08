namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

public sealed class KeycloakOptions
{
    public string AdminUrl { get; set; }
    public string TokenUrl { get; set; }
    public string PublicClientId { get; set; }
    public string ConfidentialClientId { get; set; }
    public string ConfidentialClientSecret { get; set; }
    public string? ExecuteActionsEmailClientId { get; set; }
    public string? ExecuteActionsEmailRedirectUri { get; set; }
    public int? ExecuteActionsEmailLifespan { get; set; }
}
using System.Text.Json.Serialization;

namespace LanosCertifiedStore.Infrastructure.Services.Authentication.Keycloak;

internal sealed class KeycloakAdminAuthToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = null!;
}
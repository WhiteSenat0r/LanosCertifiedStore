using System.Text.Json.Serialization;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication.KeyCloak;

internal sealed class AuthToken
{
    [JsonPropertyName("access_token")]
    public string AcessToken { get; set; }
}
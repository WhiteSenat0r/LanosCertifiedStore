using System.Net.Http.Json;

namespace LanosCertifiedStore.Infrastructure.Services.Authentication.Keycloak;

internal sealed class KeycloakClient(HttpClient httpClient)
{
    private const string BaseRequestUri = "users";

    internal async Task UpdateUserDataAsync(
        Guid userId,
        UserRepresentation user,
        CancellationToken cancellationToken = default)
    {
        var requestUri = BaseRequestUri + "/" + userId.ToString();

        var httpResponseMessage = await httpClient.PutAsJsonAsync(
            requestUri,
            user,
            cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
}
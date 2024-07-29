using System.Net.Http.Json;

namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed class KeycloakClient(HttpClient httpClient)
{
    private const string BaseRequestUri = "users";

    internal async Task<UserDataRepresentation> GetUserDataAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var requestUri = BaseRequestUri + "/" + userId;

        var httpResponseMessage = await httpClient.GetAsync(requestUri, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        return (await httpResponseMessage.Content.ReadFromJsonAsync<UserDataRepresentation>(cancellationToken))!;
    }
    
    internal async Task UpdateUserDataAsync(
        Guid userId,
        UserRepresentation user,
        CancellationToken cancellationToken = default)
    {
        var requestUri = BaseRequestUri + "/" + userId;

        var httpResponseMessage = await httpClient.PutAsJsonAsync(
            requestUri,
            user,
            cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
    
    internal async Task ClearUserSessionsAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var requestUri = BaseRequestUri + "/" + userId + "/logout";

        var httpResponseMessage = await httpClient.PostAsync(requestUri, null, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
}
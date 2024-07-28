using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed class KeycloakClient(HttpClient httpClient, IConfiguration configuration)
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
    
    // TODO fix issue with mailing
    internal async Task SendUserActionRelatedEmailAsync(
        Guid userId,
        KeycloakExecuteEmailActions emailAction,
        CancellationToken cancellationToken = default)
    {
        var clientUrl = configuration["ClientUrl"];
        var clientId = configuration.GetSection("Keycloak")["ConfidentialClientId"];
        
        var requestUri = 
            BaseRequestUri + "/" + userId + $"/execute-actions-email?client_id={clientId}&redirect_uri={clientUrl}";

        var httpResponseMessage = await httpClient.PutAsJsonAsync(
            requestUri,
            emailAction,
            cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
    }
}
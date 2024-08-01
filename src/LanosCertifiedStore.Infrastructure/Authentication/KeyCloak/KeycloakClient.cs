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

    /// <summary>
    /// Registers a user in the keycloak system asynchronously.
    /// </summary>
    /// <remarks>
    /// This method is intended for integration testing purposes only.
    /// User registration should be handled on the Keycloak side.
    /// </remarks>
    /// <param name="user">The user representation with password and ID to register.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the request.</param>
    internal async Task<string> RegisterUserAsync(
        UserRepresentationWithPasswordAndId user,
        CancellationToken cancellationToken = default)
    {
        var httpResponseMessage = await httpClient.PostAsJsonAsync(BaseRequestUri, user, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();
        
        return ExtractIdentityIdFromLocationHeader(httpResponseMessage);
    }

    private static string ExtractIdentityIdFromLocationHeader(
        HttpResponseMessage httpResponseMessage)
    {
        const string usersSegmentName = "users/";

        var locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery;

        if (locationHeader is null)
        {
            throw new InvalidOperationException("Location header is null");
        }

        var userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);

        var identityId = locationHeader.Substring(userSegmentValueIndex + usersSegmentName.Length);

        return identityId;
    }
}
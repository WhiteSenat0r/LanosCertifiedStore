using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed class KeycloakAuthDelegatingHandler(IOptions<KeycloakOptions> options) : DelegatingHandler
{
    private readonly KeycloakOptions _options = options.Value;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var authToken = await GetAuthorizationToken(cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken.AccessToken);

        var httpResponseMessage = await base.SendAsync(request, cancellationToken);

        var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync(); 

        httpResponseMessage.EnsureSuccessStatusCode();

        return httpResponseMessage;
    }

    private async Task<KeycloakAdminAuthToken> GetAuthorizationToken(CancellationToken cancellationToken)
    {
        var authRequestParams = new Dictionary<string, string>
        {
            { "client_id", _options.ConfidentialClientId },
            { "client_secret", _options.ConfidentialClientSecret },
            { "scope", "openid" },
            { "grant_type", "client_credentials" }
        };

        using var authRequestContext = new FormUrlEncodedContent(authRequestParams);

        using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(_options.TokenUrl));

        authRequest.Content = authRequestContext;

        using var authorizationResponse = await base.SendAsync(authRequest, cancellationToken);

        authorizationResponse.EnsureSuccessStatusCode();

        return (await authorizationResponse.Content.ReadFromJsonAsync<KeycloakAdminAuthToken>(cancellationToken))!;
    }
}
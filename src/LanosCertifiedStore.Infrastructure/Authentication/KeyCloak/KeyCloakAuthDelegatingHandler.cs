﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication.KeyCloak;

internal sealed class KeyCloakAuthDelegatingHandler(IOptions<KeyCloakOptions> options) : DelegatingHandler
{
    private readonly KeyCloakOptions _options = options.Value;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var authToken = await GetAuthorizationToken(cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authToken.AcessToken);

        var httpResponseMessage = await base.SendAsync(request, cancellationToken);

        httpResponseMessage.EnsureSuccessStatusCode();

        return httpResponseMessage;
    }

    private async Task<AuthToken> GetAuthorizationToken(CancellationToken cancellationToken)
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

        return (await authorizationResponse.Content.ReadFromJsonAsync<AuthToken>(cancellationToken))!;
    }
}
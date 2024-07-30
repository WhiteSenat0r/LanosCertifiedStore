using System.Net.Http.Json;
using System.Text.Json.Serialization;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationTests.Common;

[Collection(CollectionName)]
public abstract class IntegrationTestBase : IClassFixture<IntegrationTestsWebApplicationFactory>, IDisposable
{
    private protected readonly IServiceScope Scope;
    private protected readonly ISender Sender;
    private protected readonly ApplicationDatabaseContext Context;
    private protected readonly HttpClient HttpClient;
    private protected readonly KeycloakOptions KeycloakOptions;

    private const string CollectionName = "Integration tests collection";
    private protected IntegrationTestBase(IntegrationTestsWebApplicationFactory factory)
    {
        Scope = factory.Services.CreateScope();
        Sender = Scope.ServiceProvider.GetRequiredService<ISender>();
        Context = Scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
        HttpClient = factory.CreateClient();
        KeycloakOptions = Scope.ServiceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;
    }

    public void Dispose()
    {
        Scope.Dispose();
        Context.Dispose();
    }
    
    protected async Task<string> GetAccessTokenAsync(string email, string password)
    {
        using var client = new HttpClient();

        var authRequestParameters = new KeyValuePair<string, string>[]
        {
            new("client_id", KeycloakOptions.PublicClientId),
            new("scope", "openid"),
            new("grant_type", "password"),
            new("username", email),
            new("password", password)
        };

        using var authRequestContent = new FormUrlEncodedContent(authRequestParameters);

        using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(KeycloakOptions.TokenUrl));
        authRequest.Content = authRequestContent;

        using var authorizationResponse = await client.SendAsync(authRequest);

        authorizationResponse.EnsureSuccessStatusCode();
        
        var authToken = await authorizationResponse.Content.ReadFromJsonAsync<AuthToken>();

        return authToken!.AccessToken;
    }
    
    protected async Task<string> GetConfidentialAccessTokenAsync()
    {
        using var client = new HttpClient();

        var authRequestParams = new Dictionary<string, string>
        {
            { "client_id", KeycloakOptions.ConfidentialClientId },
            { "client_secret", KeycloakOptions.ConfidentialClientSecret },
            { "scope", "openid" },
            { "grant_type", "client_credentials" }
        };

        using var authRequestContent = new FormUrlEncodedContent(authRequestParams);

        using var authRequest = new HttpRequestMessage(HttpMethod.Post, new Uri(KeycloakOptions.TokenUrl));
        authRequest.Content = authRequestContent;

        using var authorizationResponse = await client.SendAsync(authRequest);

        authorizationResponse.EnsureSuccessStatusCode();
        
        var authToken = await authorizationResponse.Content.ReadFromJsonAsync<AuthToken>();

        return authToken!.AccessToken;
    }
    
    private sealed class AuthToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; } = null!;
    }
}
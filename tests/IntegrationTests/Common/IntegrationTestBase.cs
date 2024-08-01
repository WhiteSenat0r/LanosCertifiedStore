using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Bogus;
using IntegrationTests.Identity;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IntegrationTests.Common;

[Collection(CollectionName)]
public abstract class IntegrationTestBase : IClassFixture<IntegrationTestsWebApplicationFactory>, IDisposable
{
    private const string CollectionName = "Integration tests collection";
    private readonly IServiceScope _scope;


    private protected static readonly Faker Faker = new("uk");
    private protected readonly ISender Sender;
    private protected readonly ApplicationDatabaseContext Context;
    private protected readonly HttpClient HttpClient;
    private protected readonly KeycloakClient KeycloakClient;
    private protected readonly KeycloakOptions KeycloakOptions;

    private protected IntegrationTestBase(IntegrationTestsWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Context = _scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
        HttpClient = factory.CreateClient();
        KeycloakClient = factory.Services.GetRequiredService<KeycloakClient>();
        KeycloakOptions = _scope.ServiceProvider.GetRequiredService<IOptions<KeycloakOptions>>().Value;
    }

    public void Dispose()
    {
        _scope.Dispose();
        Context.Dispose();
    }

    internal async Task<UserRepresentationWithPasswordAndId> RegisterUserOnKeycloakAndAddToDb(
        string email,
        string password,
        string phoneNumber,
        UserRole role)
    {
        var userRepresentation = TestExemplars
            .GetCorrectUserRepresentationWithPasswordAndId(email, password, phoneNumber);

        var userId = Guid.Parse(await KeycloakClient.RegisterUserAsync(userRepresentation));

        var user = new User(userId)
        {
            UserRole = role
        };
        
        Context.Attach(role);
        await Context.Set<User>().AddAsync(user);
        await Context.SaveChangesAsync();

        return userRepresentation with
        {
            Id = userId
        };
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

    private sealed class AuthToken
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; init; } = null!;
    }
}
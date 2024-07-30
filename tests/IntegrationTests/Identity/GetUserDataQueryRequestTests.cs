using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

public sealed class GetUserDataQueryRequestTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    private const string Email = "test@test.com";
    private const string Password = "123";

    [Fact]
    public async Task Send_Should_ReturnFailureResult_IfUserDoesNotExist()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        var result = await Sender.Send(new GetUserDataQueryRequest(userId));

        // Assert
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(userId));
        result.IsSuccess
            .Should().BeFalse();
    }

    [Fact]
    public async Task Send_Should_ReturnSuccessResult_IfUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = await RegisterNewUser(userId);

        // Act
        var result = await Sender.Send(new GetUserDataQueryRequest(userId));

        // Assert
        result.Error
            .Should().BeEquivalentTo(Error.None);
        result.Value
            .Should().NotBeNull();
        result.Value!.Email
            .Should().Be(Email);
    }
    

    private async Task<UserRepresentationWithPassword> RegisterNewUser(Guid id)
    {
        var user = new UserRepresentationWithPassword(
            id.ToString(),
            Email,
            Email,
            true,
            null!,
            "test",
            "test",
            new CredentialRepresentation("password", Password, false));

        var uri = KeycloakOptions.AdminUrl + "users";
        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            await GetConfidentialAccessTokenAsync());

        var jsonContent = JsonSerializer.Serialize(user);
        httpRequestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        using var responseMessage = await HttpClient.SendAsync(httpRequestMessage);

        // TODO FIGURE OUT WHY DOES IT RETURN NOTFOUND AND WHY DOES IT TRIGGER CustomClaimsTransformation.TransformAsync 
        // TODO try one of the solutions: adding RegisterUser method to keycloak client idk how tho
        
        var response = await responseMessage.Content.ReadAsStringAsync();

        responseMessage.EnsureSuccessStatusCode();

        return user;
    }
}


internal sealed record UserRepresentationWithPassword(
    string Id,
    string Username,
    string Email,
    bool EmailVerified,
    Dictionary<string, string> Attributes,
    string FirstName,
    string LastName,
    CredentialRepresentation CredentialRepresentation,
    List<string> RequiredActions = null!)
    : UserRepresentation(Username, Email, EmailVerified, Attributes, FirstName, LastName, RequiredActions);
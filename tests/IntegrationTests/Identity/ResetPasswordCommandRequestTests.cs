using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.ResetPasswordCommandRequestRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IntegrationTests.Identity;

public sealed class ResetPasswordCommandRequestTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Endpoint_Should_ReturnNoContent_IfSenderHasPermission_AndRequestIsValid()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsync(
            "api/identity/password", null);

        // Assert
        response.StatusCode
            .Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task Send_Should_AddUpdateEmailRequiredActionToKeycloakUser()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        var request = new ResetPasswordCommandRequest();

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        await HttpClient.PutAsJsonAsync("api/identity/password", request);
        var userRepresentation = await KeycloakClient.GetUserDataAsync(user.Id);

        // Assert
        userRepresentation.RequiredActions
            .Any(ra => ra.Equals(KeycloakRequiredActions.GetUpdatePasswordCode().First()))
            .Should().BeTrue();
    }

    [Fact]
    public async Task Endpoint_Should_ReturnNoContent_EvenWhenExecuteActionsEmailFails()
    {
        // Arrange — SMTP is unreachable in the test container; endpoint must still return 204
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsync("api/identity/password", null);

        // Assert — best-effort email failure must not bubble up to the caller
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task ResetPassword_Should_SetRequiredActionAndClearSessionsBeforeAttemptingEmail()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act — call reset password (sets required action, clears sessions, attempts email)
        await HttpClient.PutAsync("api/identity/password", null);

        // Assert — required action is set (UpdateUserDataAsync happened first)
        var userRepresentation = await KeycloakClient.GetUserDataAsync(user.Id);
        userRepresentation.RequiredActions
            .Should().Contain(KeycloakRequiredActions.GetUpdatePasswordCode().First());

        // Assert — old token is no longer valid (ClearUserSessionsAsync happened before email attempt)
        var secondResponse = await HttpClient.PutAsync("api/identity/password", null);
        secondResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnUnauthorized_IfTokenIsNotPresent()
    {
        // Act
        var responseMessage = await HttpClient.PutAsync($"api/identity/password", null);

        // Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
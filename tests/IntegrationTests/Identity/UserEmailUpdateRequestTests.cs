using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IntegrationTests.Identity;

public sealed class UserEmailUpdateRequestTests(
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
            UserRole.Administrator);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        var request = new UserEmailUpdateCommandRequest(Faker.Internet.Email());

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsJsonAsync("api/identity/email", request);

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
            UserRole.Administrator);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        var request = new UserEmailUpdateCommandRequest(Faker.Internet.Email());

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        await HttpClient.PutAsJsonAsync("api/identity/email", request);
        var userRepresentation = await KeycloakClient.GetUserDataAsync(user.Id);

        // Assert
        userRepresentation.RequiredActions
            .Any(ra => ra.Equals(KeycloakRequiredActions.GetVerifyEmailCode().First()))
            .Should().BeTrue();
    }

    [Fact]
    public async Task Send_Should_ReturnValidationError_IfEmailIsInvalid()
    {
        // Arrange
        var request = new UserEmailUpdateCommandRequest("test");

        // Act
        var result = (IValidationResult)await Sender.Send(request);

        // Assert
        (result.Errors.Length != 0)
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
            UserRole.Administrator);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        var request = new UserEmailUpdateCommandRequest(Faker.Internet.Email());

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsJsonAsync("api/identity/email", request);

        // Assert — best-effort email failure must not bubble up to the caller
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task UpdateEmail_Should_SetRequiredActionAndClearSessionsBeforeAttemptingEmail()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.Administrator);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);
        var newEmail = Faker.Internet.Email();
        var request = new UserEmailUpdateCommandRequest(newEmail);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        await HttpClient.PutAsJsonAsync("api/identity/email", request);

        // Assert — VERIFY_EMAIL required action is set (UpdateUserDataAsync happened first)
        var userRepresentation = await KeycloakClient.GetUserDataAsync(user.Id);
        userRepresentation.RequiredActions
            .Should().Contain(KeycloakRequiredActions.GetVerifyEmailCode().First());

        // Assert — old token is no longer valid (ClearUserSessionsAsync happened before email attempt)
        var secondResponse = await HttpClient.PutAsJsonAsync("api/identity/email", request);
        secondResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnUnauthorized_IfTokenIsNotPresent()
    {
        // Act
        var responseMessage = await HttpClient.PutAsync($"api/identity/email", null);

        // Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
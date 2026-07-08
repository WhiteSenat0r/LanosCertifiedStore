using IntegrationTests.Common;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

public sealed class SendExecuteActionsEmailTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public void KeycloakOptions_Should_HaveExecuteActionsEmailClientIdConfigured()
    {
        KeycloakOptions.ExecuteActionsEmailClientId
            .Should().Be("lsc-public-auth-client");
    }

    [Fact]
    public void KeycloakOptions_Should_HaveExecuteActionsEmailLifespanConfigured()
    {
        KeycloakOptions.ExecuteActionsEmailLifespan
            .Should().Be(300);
    }

    [Fact]
    public async Task SendExecuteActionsEmail_Should_ThrowHttpRequestException_WhenUserDoesNotExist()
    {
        // Arrange — a non-existent user guarantees Keycloak returns 404
        var nonExistentUserId = Guid.NewGuid();

        // Act
        var act = () => KeycloakClient.SendExecuteActionsEmailAsync(
            nonExistentUserId,
            KeycloakRequiredActions.GetVerifyEmailCode(),
            KeycloakOptions.ExecuteActionsEmailClientId,
            KeycloakOptions.ExecuteActionsEmailRedirectUri,
            KeycloakOptions.ExecuteActionsEmailLifespan);

        // Assert — Keycloak returns 404 → KeycloakAuthDelegatingHandler throws HttpRequestException
        await act.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task SendExecuteActionsEmail_UpdatePassword_Should_ThrowHttpRequestException_WhenUserDoesNotExist()
    {
        // Arrange — a non-existent user guarantees Keycloak returns 404 for UPDATE_PASSWORD action too
        var nonExistentUserId = Guid.NewGuid();

        // Act
        var act = () => KeycloakClient.SendExecuteActionsEmailAsync(
            nonExistentUserId,
            KeycloakRequiredActions.GetUpdatePasswordCode(),
            KeycloakOptions.ExecuteActionsEmailClientId,
            KeycloakOptions.ExecuteActionsEmailRedirectUri,
            KeycloakOptions.ExecuteActionsEmailLifespan);

        // Assert
        await act.Should().ThrowAsync<HttpRequestException>();
    }

    [Fact]
    public async Task SendExecuteActionsEmail_Should_PropagateOperationCanceledException_WhenTokenIsCancelled()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act
        var act = () => KeycloakClient.SendExecuteActionsEmailAsync(
            user.Id,
            KeycloakRequiredActions.GetVerifyEmailCode(),
            KeycloakOptions.ExecuteActionsEmailClientId,
            KeycloakOptions.ExecuteActionsEmailRedirectUri,
            KeycloakOptions.ExecuteActionsEmailLifespan,
            cts.Token);

        // Assert — OperationCanceledException is NOT caught by TrySendExecuteActionsEmailAsync
        await act.Should().ThrowAsync<OperationCanceledException>();
    }
}

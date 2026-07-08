using System.Net;
using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.Infrastructure.Authentication;

internal sealed class IdentityProviderService(
    KeycloakClient keycloakClient,
    ILogger<IdentityProviderService> logger,
    IOptions<KeycloakOptions> keycloakOptions) : IIdentityProviderService
{
    private readonly KeycloakOptions _keycloakOptions = keycloakOptions.Value;

    public async Task<Result<UserDataDto>> GetUserDataAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var userDataRepresentation = await keycloakClient.GetUserDataAsync(userId, cancellationToken);

            var userDataDto = new UserDataDto(
                userDataRepresentation.Id,
                userDataRepresentation.FirstName,
                userDataRepresentation.LastName,
                userDataRepresentation.Email,
                userDataRepresentation.Attributes?.PhoneNumber.FirstOrDefault(),
                userDataRepresentation.EmailVerified,
                userDataRepresentation.FederatedIdentities,
                userDataRepresentation.CreatedTimestamp);

            return userDataDto;
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            var error = Error.NotFound(userId);

            logger.LogError(e, error.Message);

            return Result<UserDataDto>.Failure(error);
        }
    }

    public async Task<Result> UpdateUserDataAsync(
        Guid userId,
        string phoneNumber,
        string email,
        string firstName,
        string lastName,
        CancellationToken cancellationToken = default,
        bool emailVerified = true,
        List<string>? requiredActions = null!)
    {
        var attributes = new Dictionary<string, string>
        {
            { "phoneNumber", phoneNumber }
        };

        var userRepresentation = new UserRepresentation(
            Username: email,
            Email: email,
            EmailVerified: emailVerified,
            Attributes: attributes,
            FirstName: firstName,
            LastName: lastName,
            RequiredActions: requiredActions ?? []
        );

        try
        {
            await keycloakClient.UpdateUserDataAsync(userId, userRepresentation, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            var error = Error.NotFound(userId);

            logger.LogError(e, error.Message);

            return Result.Create(error);
        }
    }

    public async Task<Result> UpdateUserEmailAsync(
        Guid userId,
        string newEmail,
        CancellationToken cancellationToken)
    {
        var userRepresentationResult = await GetSuitableEmailUpdateUserRepresentation(
            userId,
            newEmail,
            cancellationToken);

        if (!userRepresentationResult.IsSuccess)
        {
            return userRepresentationResult;
        }

        await keycloakClient.UpdateUserDataAsync(
            userId,
            userRepresentationResult.Value!,
            cancellationToken);

        await keycloakClient.ClearUserSessionsAsync(userId, cancellationToken);

        await TrySendExecuteActionsEmailAsync(
            userId,
            KeycloakRequiredActions.GetVerifyEmailCode());

        return Result.Create(Error.None);
    }

    public async Task<Result> ResetUserPassword(Guid id, CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
            null!,
            null!,
            true,
            null!,
            null!,
            null!,
            RequiredActions: KeycloakRequiredActions.GetUpdatePasswordCode());

        try
        {
            await keycloakClient.UpdateUserDataAsync(id, userRepresentation, cancellationToken);
            await keycloakClient.ClearUserSessionsAsync(id, cancellationToken);
        }
        catch (HttpRequestException)
        {
            return Result.Create(IdentityErrors.ResetPasswordError);
        }

        await TrySendExecuteActionsEmailAsync(
            id,
            KeycloakRequiredActions.GetUpdatePasswordCode());

        return Result.Create(Error.None);
    }

    private async Task TrySendExecuteActionsEmailAsync(
        Guid userId,
        IReadOnlyList<string> actions)
    {
        try
        {
            await keycloakClient.SendExecuteActionsEmailAsync(
                userId,
                actions,
                _keycloakOptions.ExecuteActionsEmailClientId,
                _keycloakOptions.ExecuteActionsEmailRedirectUri,
                _keycloakOptions.ExecuteActionsEmailLifespan,
                CancellationToken.None);
        }
        catch (HttpRequestException e)
        {
            logger.LogWarning(e, "Failed to send execute-actions email for user {UserId}.", userId);
        }
    }

    private async Task<Result<UserRepresentation>> GetSuitableEmailUpdateUserRepresentation(
        Guid userId,
        string newEmail,
        CancellationToken cancellationToken)
    {
        try
        {
            var userDataRepresentation = await keycloakClient.GetUserDataAsync(userId, cancellationToken);

            var attributes = new Dictionary<string, string>
            {
                { "phoneNumber", userDataRepresentation.Attributes!.PhoneNumber.FirstOrDefault()! }
            };

            var userRepresentation = new UserRepresentation(
                Username: newEmail,
                Email: newEmail,
                EmailVerified: false,
                Attributes: attributes,
                FirstName: userDataRepresentation.FirstName,
                LastName: userDataRepresentation.LastName,
                RequiredActions: KeycloakRequiredActions.GetVerifyEmailCode()
            );

            return userRepresentation;
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            var error = Error.NotFound(userId);

            logger.LogError(e, error.Message);

            return Result<UserRepresentation>.Failure(error);
        }
    }
}
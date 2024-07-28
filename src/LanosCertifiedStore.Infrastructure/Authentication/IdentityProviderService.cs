using System.Net;
using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Infrastructure.Authentication.Keycloak;
using Microsoft.Extensions.Logging;

namespace LanosCertifiedStore.Infrastructure.Authentication;

internal sealed class IdentityProviderService(
    KeycloakClient keycloakClient,
    ILogger<IdentityProviderService> logger) : IIdentityProviderService
{
    public async Task<Result<UserDataDto>> GetUserDataAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await keycloakClient.GetUserDataAsync(userId, cancellationToken);
            return Result<UserDataDto>.Success(result);
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            const string userWithProvidedItWasNotFound = "User with provided it was not found!";
            logger.LogError(e, userWithProvidedItWasNotFound);
            return Result<UserDataDto>.Failure(Error.NotFound(userId));
        }
    }

    public async Task<Result> UpdateUserDataAsync(
        UpdateUserDataCommandRequest request,
        CancellationToken cancellationToken = default)
    {
        var attributes = new Dictionary<string, string>()
        {
            { "phoneNumber", request.PhoneNumber }
        };

        var userRepresentation = new UserRepresentation(
            Username: request.Email,
            Email: request.Email,
            Attributes: attributes,
            request.FirstName,
            request.LastName
        );

        try
        {
            await keycloakClient.UpdateUserDataAsync(request.Id, userRepresentation, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            logger.LogError(e, "User with provided it was not found!");
            return Result.Create(Error.NotFound(request.Id));
        }
    }
}
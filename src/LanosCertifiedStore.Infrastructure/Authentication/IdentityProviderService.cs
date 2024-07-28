using System.Net;
using LanosCertifiedStore.Application.Identity;
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
        Guid id,
        string phoneNumber,
        string email,
        string firstName,
        string lastName,
        CancellationToken cancellationToken = default)
    {
        var attributes = new Dictionary<string, string>()
        {
            { "phoneNumber", phoneNumber }
        };

        var userRepresentation = new UserRepresentation(
            Username: email,
            Email: email,
            Attributes: attributes,
            firstName,
            lastName
        );

        try
        {
            await keycloakClient.UpdateUserDataAsync(id, userRepresentation, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (HttpRequestException e) when (e.StatusCode is HttpStatusCode.NotFound)
        {
            var error = Error.NotFound(id);
            logger.LogError(e, error.Message);
            return Result.Create(error);
        }
    }
}
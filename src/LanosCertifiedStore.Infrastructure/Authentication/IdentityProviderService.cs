using System.Net;
using Application.Identity;
using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using Application.Shared.ResultRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Authentication.KeyCloak;
using Microsoft.Extensions.Logging;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication;

internal sealed class IdentityProviderService(
    KeyCloakClient keyCloakClient,
    ILogger<IdentityProviderService> logger) : IIdentityProviderService
{
    private const string PasswordCredentialType = "Password";

    public async Task<Result<string>> RegisterAsync(
        RegisterUserCommandRequest commandRequest,
        CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
            commandRequest.Email,
            commandRequest.Email,
            // commandRequest.PhoneNumber,
            commandRequest.FirstName,
            commandRequest.LastName,
            EmailVerified: false,
            Enabled: true,
            [new CredentialRepresentation(PasswordCredentialType, commandRequest.Password, false)]);

        try
        {
            var identityId = await keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);

            return Result<string>.Success(identityId);
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.Conflict)
        {
            logger.LogError(e, "User registration failed");

            return Result<string>.Failure(IdentityProviderErrors.EmailIsNotUnique);
        }
    }
}
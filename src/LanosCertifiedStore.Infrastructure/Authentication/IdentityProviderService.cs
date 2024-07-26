using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.RegisterUserCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Infrastructure.Services.Authentication.Keycloak;
using Microsoft.Extensions.Logging;

namespace LanosCertifiedStore.Infrastructure.Services.Authentication;

internal sealed class IdentityProviderService(
    KeycloakClient keycloakClient,
    ILogger<IdentityProviderService> logger) : IIdentityProviderService
{
    public async Task<Result<string>> RegisterAsync(
        AddUserFromProviderCommandRequest fromProviderCommandRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
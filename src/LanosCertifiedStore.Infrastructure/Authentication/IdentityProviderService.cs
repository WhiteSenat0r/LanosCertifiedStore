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
    public async Task<Result<string>> RegisterAsync(
        RegisterUserCommandRequest commandRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
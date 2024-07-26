using LanosCertifiedStore.Application.Identity.Commands.RegisterUserCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterAsync(
        AddUserFromProviderCommandRequest fromProviderCommandRequest,
        CancellationToken cancellationToken = default);
}
using LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterAsync(
        AddUserFromProviderCommandRequest fromProviderCommandRequest,
        CancellationToken cancellationToken = default);
}
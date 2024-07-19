using Application.Identity.Commands.RegisterUserCommandRequestRelated;
using Application.Shared.ResultRelated;

namespace Application.Identity;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterAsync(
        RegisterUserCommandRequest commandRequest,
        CancellationToken cancellationToken = default);
}
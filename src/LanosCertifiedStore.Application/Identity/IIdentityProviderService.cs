using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public interface IIdentityProviderService
{
    Task<Result> UpdateUserDataAsync(
        UpdateUserDataCommandRequest request,
        CancellationToken cancellationToken = default);
}
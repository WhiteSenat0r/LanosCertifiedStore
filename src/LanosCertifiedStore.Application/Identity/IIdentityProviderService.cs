using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public interface IIdentityProviderService
{
    Task<Result<UserDataDto>> GetUserDataAsync(
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateUserDataAsync(
        Guid id,
        string phoneNumber,
        string email,
        string firstName,
        string lastName,
        CancellationToken cancellationToken = default);
}
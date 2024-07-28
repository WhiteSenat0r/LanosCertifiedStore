using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public interface IIdentityProviderService
{
    Task<Result<UserDataDto>> GetUserDataAsync(
        Guid userId,
        CancellationToken cancellationToken = default);

    Task<Result> UpdateUserDataAsync(
        Guid userId,
        string phoneNumber,
        string email,
        string firstName,
        string lastName,
        CancellationToken cancellationToken = default,
        bool emailVerified = true);

    Task<Result> UpdateUserEmailAsync(
        Guid userId,
        string newEmail,
        CancellationToken cancellationToken = default);
}
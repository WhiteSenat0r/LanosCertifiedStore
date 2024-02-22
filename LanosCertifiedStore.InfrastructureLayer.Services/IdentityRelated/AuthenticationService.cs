using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.RequestParams;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.UserRelated;

namespace LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated;

internal sealed class AuthenticationService(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher) : IAuthenticationService
{
    public async Task<User?> LoginAsync(LoginDto loginDto)
    {
        var filteringParamsForGettingUserByEmail = new UserFilteringRequestParameters()
        {
            Email = loginDto.Email
        };

        var user = (await unitOfWork.RetrieveRepository<User>()
            .GetAllEntitiesAsync(filteringParamsForGettingUserByEmail)).SingleOrDefault();

        if (user is null)
            return null;

        var isPasswordCorrect = passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);

        return isPasswordCorrect ? user : null;
    }

    public async Task<User?> RegisterAsync(RegisterDto registerDto)
    {
        var passwordHash = passwordHasher.HashPassword(registerDto.Password);

        var user = new User(registerDto.FirstName, registerDto.LastName, registerDto.Email, passwordHash);

        await unitOfWork.RetrieveRepository<User>().AddNewEntityAsync(user);

        return user;
    }
}
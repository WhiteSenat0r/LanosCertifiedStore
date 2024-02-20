using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Dtos.IdentityDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace LanosCertifiedStore.InfrastructureLayer.Services.IdentityRelated;

internal sealed class AuthenticationService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher) : IAuthenticationService
{
    public async Task<User?> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.GetUserByEmailAsync(loginDto.Email);

        passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);
        
        return user;
    }

    public async Task<User?> RegisterAsync(RegisterDto registerDto)
    {
        var user = new User(registerDto.FirstName, registerDto.LastName, registerDto.Email);

        await userRepository.CreateUserAsync(user, passwordHasher.HashPassword(registerDto.Password));

        return user;
    }
}
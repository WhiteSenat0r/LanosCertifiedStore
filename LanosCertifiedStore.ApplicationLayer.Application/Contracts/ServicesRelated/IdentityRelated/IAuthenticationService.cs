using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Domain.Entities.UserRelated;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IAuthenticationService
{
    Task<User?> LoginAsync(LoginDto loginDto);
    Task<User?> RegisterAsync(RegisterDto registerDto);
}
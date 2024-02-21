using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IAuthenticationService
{
    Task<User?> LoginAsync(LoginDto loginDto);
    Task<User?> RegisterAsync(RegisterDto registerDto);
}
using Application.Identity.Dtos.AuthenticationDtos;
using Domain.Entities.UserRelated;
using Microsoft.AspNetCore.Http;

namespace Application.Identity.ServicesContracts;

public interface IAuthenticationService
{
    Task<User?> LoginAsync(LoginDto loginDto, HttpResponse httpResponse);
    Task<User?> RegisterAsync(RegisterDto registerDto);
    IDictionary<string, bool> GetAuthenticationStatus(HttpRequest httpRequest);
}
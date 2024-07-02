﻿using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.RequestParameters;
using Domain.Entities.UserRelated;
using LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated.JwtTokenRelated;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated;

internal sealed class AuthenticationService(
    IPasswordHasher passwordHasher,
    IOptions<JwtTokenOptions> jwtOptions) : IAuthenticationService
{
    public async Task<User?> LoginAsync(LoginDto loginDto, HttpResponse httpResponse)
    {
        var filteringParamsForGettingUserByEmail = new UserFilteringRequestParameters
        {
            Email = loginDto.Email
        };

        // var user = (await unitOfWork.RetrieveRepository<User>()
        //     .GetAllEntitiesAsync(filteringParamsForGettingUserByEmail)).SingleOrDefault();
        //
        // if (user is null) return null;
        //
        // var isPasswordCorrect = passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);
        //
        // if (!isPasswordCorrect) return null;
        //
        // AppendUserAccessTokenCookie(httpResponse, user);
        //
        // return user;

        throw new NotImplementedException();
    }

    public async Task<User?> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
        // var passwordHash = passwordHasher.HashPassword(registerDto.Password);
        //
        // var user = new User(registerDto.FirstName, registerDto.LastName, registerDto.Email, passwordHash);
        //
        // await unitOfWork.RetrieveRepository<User>().AddNewEntityAsync(user);
        //
        // return user;
    }

    public IDictionary<string, bool> GetAuthenticationStatus(HttpRequest httpRequest) =>
        new Dictionary<string, bool>
        {
            { "isValidAccessToken", httpRequest.Cookies.ContainsKey("UserAccessToken") },
            { "isValidRefreshToken", httpRequest.Cookies.ContainsKey("UserRefreshToken") }
        };

    private void AppendUserAccessTokenCookie(HttpResponse httpResponse, User user)
    {
        var accessToken = new JwtTokenProvider(jwtOptions.Value).Generate(user);

        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTime.UtcNow.AddMinutes(5)
        };
        
        httpResponse.Cookies.Append(
            "UserAccessToken", accessToken, cookieOptions);
    }
}
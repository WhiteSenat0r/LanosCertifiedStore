using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Shared.ResultRelated;
using AutoMapper;
using Domain.Entities.UserRelated;
using MediatR;

namespace Application.CommandRequests.Identity.Authentication.Login;

internal sealed class LoginCommandHandler(IAuthenticationService authenticationService, IMapper mapper)
    : IRequestHandler<LoginCommand, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var userLoginResult = await authenticationService.LoginAsync(request.LoginDto, request.HttpResponse);

        if (userLoginResult is null)
        {
            return Result<UserDto>.Failure(new Error("Unauthorized", "Failed to login with provided credentials"));
        }

        var userDto = mapper.Map<User, UserDto>(userLoginResult);
        
        return Result<UserDto>.Success(userDto);
    }
}
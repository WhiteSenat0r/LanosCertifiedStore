﻿using Application.Contracts.ServicesRelated.IdentityRelated;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.UserRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Authentication.Register;

internal sealed class RegisterCommandHandler(
    IAuthenticationService authenticationService,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RegisterCommand, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userRegisterResult = await authenticationService.RegisterAsync(request.RegisterDto);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<UserDto>.Success(mapper.Map<User, UserDto>(userRegisterResult!))
            : Result<UserDto>.Failure(new Error("Unauthorized", "Registration has failed"));
    }
}
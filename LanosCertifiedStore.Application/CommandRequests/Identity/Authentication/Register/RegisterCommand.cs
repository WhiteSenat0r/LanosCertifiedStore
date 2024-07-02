﻿using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Identity.Authentication.Register;

public sealed record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result<UserDto>>;
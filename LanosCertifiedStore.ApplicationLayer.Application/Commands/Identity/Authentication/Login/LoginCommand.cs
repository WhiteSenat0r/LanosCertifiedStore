using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Authentication.Login;

public sealed record LoginCommand(LoginDto LoginDto) : IRequest<Result<UserDto>>;
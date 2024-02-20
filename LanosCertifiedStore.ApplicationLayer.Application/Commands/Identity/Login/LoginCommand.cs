using Application.Dtos.IdentityDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Login;

public sealed record LoginCommand(LoginDto LoginDto) : IRequest<Result<UserDto>>;
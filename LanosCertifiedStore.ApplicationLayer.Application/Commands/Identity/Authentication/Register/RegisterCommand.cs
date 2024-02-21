using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Authentication.Register;

public sealed record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result<UserDto>>;
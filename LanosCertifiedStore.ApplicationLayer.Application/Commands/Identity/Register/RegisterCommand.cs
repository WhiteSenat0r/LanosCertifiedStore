using Application.Dtos.IdentityDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Register;

public sealed record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result<UserDto>>;
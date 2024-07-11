using Application.Identity.Dtos.AuthenticationDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Identity.Commands.Authentication.Register;

public sealed record RegisterCommand(RegisterDto RegisterDto) : IRequest<Result<UserDto>>;
using Application.Dtos.IdentityDtos.AuthenticationDtos;
using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Identity.Authentication.Login;

public sealed record LoginCommand(LoginDto LoginDto, HttpResponse HttpResponse) : IRequest<Result<UserDto>>;
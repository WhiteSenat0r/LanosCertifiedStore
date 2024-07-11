using Application.Identity.Dtos.AuthenticationDtos;
using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Identity.Commands.Authentication.Login;

public sealed record LoginCommand(LoginDto LoginDto, HttpResponse HttpResponse) : IRequest<Result<UserDto>>;
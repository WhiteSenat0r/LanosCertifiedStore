using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Identity.Authentication.AuthenticationStatus;

public sealed record AuthenticationStatusCommand(
    HttpRequest HttpRequest) : IRequest<Result<IDictionary<string, bool>>>;
using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Identity.Commands.Authentication.AuthenticationStatus;

public sealed record AuthenticationStatusCommand(
    HttpRequest HttpRequest) : IRequest<Result<IDictionary<string, bool>>>;
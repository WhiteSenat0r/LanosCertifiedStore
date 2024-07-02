using Application.Shared.ResultRelated;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CommandRequests.Identity.Authentication.AuthenticationStatus;

public sealed record AuthenticationStatusCommand(
    HttpRequest HttpRequest) : IRequest<Result<IDictionary<string, bool>>>;
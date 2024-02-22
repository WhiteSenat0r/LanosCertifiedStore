using Application.Contracts.ServicesRelated.IdentityRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.Authentication.AuthenticationStatus;

internal sealed class AuthenticationStatusCommandHandler(
    IAuthenticationService authenticationService) 
    : IRequestHandler<AuthenticationStatusCommand, Result<IDictionary<string, bool>>>
{
    public async Task<Result<IDictionary<string, bool>>> Handle(
        AuthenticationStatusCommand request, CancellationToken cancellationToken)
    {
        var userLoginResult = authenticationService.GetAuthenticationStatus(request.HttpRequest);
        
        return Result<IDictionary<string, bool>>.Success(userLoginResult);
    }
}
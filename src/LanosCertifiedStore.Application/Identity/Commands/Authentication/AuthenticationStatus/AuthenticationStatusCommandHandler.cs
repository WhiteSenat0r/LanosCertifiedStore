using Application.Identity.ServicesContracts;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Identity.Commands.Authentication.AuthenticationStatus;

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
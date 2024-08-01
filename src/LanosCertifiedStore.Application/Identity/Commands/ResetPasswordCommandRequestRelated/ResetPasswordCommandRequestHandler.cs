using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.ResetPasswordCommandRequestRelated;

internal sealed class ResetPasswordCommandRequestHandler(
    IUserContext userContext,
    IIdentityProviderService identityProviderService) : IRequestHandler<ResetPasswordCommandRequest, Result>
{
    public async Task<Result> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;

        var result = await identityProviderService.ResetUserPassword(userId, cancellationToken);

        return result;
    }
}
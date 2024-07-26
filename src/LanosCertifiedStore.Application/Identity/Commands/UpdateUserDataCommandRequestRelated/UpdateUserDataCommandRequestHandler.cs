using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;

internal sealed class UpdateUserDataCommandRequestHandler(IIdentityProviderService identityProviderService)
    : IRequestHandler<UpdateUserDataCommandRequest, Result>
{
    public async Task<Result> Handle(UpdateUserDataCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await identityProviderService.UpdateUserDataAsync(request, cancellationToken);

        return result;
    }
}
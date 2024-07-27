using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;

internal sealed class GetUserDataQueryRequestHandler(IIdentityProviderService identityProviderService) 
    : IRequestHandler<GetUserDataQueryRequest, Result<UserDataDto>>
{
    public async Task<Result<UserDataDto>> Handle(GetUserDataQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await identityProviderService.GetUserDataAsync(request, cancellationToken);

        return result;
    }
}
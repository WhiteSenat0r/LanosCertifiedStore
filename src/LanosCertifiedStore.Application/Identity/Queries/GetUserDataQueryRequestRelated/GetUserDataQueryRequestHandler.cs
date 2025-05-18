using LanosCertifiedStore.Application.Identity.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;

internal sealed class GetUserDataQueryRequestHandler(IUserContext userContext, IIdentityProviderService identityProviderService) 
    : IRequestHandler<GetUserDataQueryRequest, Result<UserDataDto>>
{
    public async Task<Result<UserDataDto>> Handle(GetUserDataQueryRequest request, CancellationToken cancellationToken)
    {
        var userId = request.Id == default ? userContext.UserId : request.Id;
        var result = await identityProviderService.GetUserDataAsync(userId, cancellationToken);

        return result;
    }
}
using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;

internal sealed class UpdateUserSelfCommandRequestHandler(
    IIdentityProviderService identityService,
    IUserContext userContext) : IRequestHandler<UpdateUserSelfCommandRequest, Result>
{
    public async Task<Result> Handle(UpdateUserSelfCommandRequest request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;

        var userDataResult = await identityService.GetUserDataAsync(userId, cancellationToken);

        if (!userDataResult.IsSuccess)
        {
            return userDataResult;
        }

        var result = await identityService.UpdateUserDataAsync(
            userId,
            request.PhoneNumber,
            userDataResult.Value!.Email,
            request.FirstName,
            request.LastName,
            cancellationToken);

        return result;
    }
}
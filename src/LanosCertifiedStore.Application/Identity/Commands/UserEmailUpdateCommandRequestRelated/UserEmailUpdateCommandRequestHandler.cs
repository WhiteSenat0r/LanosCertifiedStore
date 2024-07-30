using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;

internal sealed class UserEmailUpdateCommandRequestHandler(
    IIdentityProviderService identityService,
    IUserContext userContext) : IRequestHandler<UserEmailUpdateCommandRequest, Result>
{
    public async Task<Result> Handle(UserEmailUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var userId = userContext.UserId;
        
        var userDataResult = await identityService.GetUserDataAsync(userId, cancellationToken);
        
        if (!userDataResult.IsSuccess)
        {
            return userDataResult;
        }

        if (userDataResult.Value!.Email.Equals(request.NewEmail))
        {
            return Result.Create(IdentityErrors.SameEmailError);
        }
        
        var result = await identityService.UpdateUserEmailAsync(
            userId,
            request.NewEmail,
            cancellationToken);
        
        return result;
    }
}
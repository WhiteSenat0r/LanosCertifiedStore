using Application.Shared.ResultRelated;
using Domain.Entities.UserRelated;
using MediatR;

namespace Application.Identity.Commands.RegisterUserCommandRequestRelated;

internal sealed class RegisterUserCommandRequestHandler(
    IUserService userService,
    IIdentityProviderService identityProviderService) : IRequestHandler<RegisterUserCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await identityProviderService.RegisterAsync(request, cancellationToken);

        if (!result.IsSuccess)
        {
            return Result<Guid>.Failure(result.Error!);
        }

        var user = new User(
            request.Email,
            request.FirstName,
            request.LastName,
            request.PhoneNumber);

        await userService.AddAsync(user, cancellationToken);

        return Result<Guid>.Success(user.Id);
    }
}
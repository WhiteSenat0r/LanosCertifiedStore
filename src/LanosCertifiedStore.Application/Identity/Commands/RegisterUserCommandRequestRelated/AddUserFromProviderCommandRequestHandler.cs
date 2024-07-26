using Application.Shared.ResultRelated;
using Application.Users;
using Domain.Entities.UserRelated;
using MediatR;

namespace Application.Identity.Commands.RegisterUserCommandRequestRelated;

internal sealed class AddUserFromProviderCommandRequestHandler(IUserService userService)
    : IRequestHandler<AddUserFromProviderCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        AddUserFromProviderCommandRequest request, CancellationToken cancellationToken)
    {
        var user = new User(request.UserId);

        await userService.AddAsync(user, cancellationToken);

        return user.Id;
    }
}
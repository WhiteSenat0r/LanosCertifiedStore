using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Identity.Commands.ChangeUserRoleCommandRequestRelated;

internal sealed class ChangeUserRoleCommandRequestHandler(
    IUserService userService) : IRequestHandler<ChangeUserRoleCommandRequest, Result>
{
    public async Task<Result> Handle(ChangeUserRoleCommandRequest request, CancellationToken cancellationToken)
    {
        var role = request.RoleCode.ToLower() switch
        {
            "user" => UserRole.User,
            "manager" => UserRole.Manager,
            _ => default
        };

        if (role is null)
        {
            return Result.Create(Error.NotFound($"Role with code {request.RoleCode} was not found or is inaccessible"));
        }

        try
        {
            await userService.ChangeUserRole(request.UserId, role, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException)
        {
            return Result.Create(Error.NotFound(request.UserId));
        }
    }
}
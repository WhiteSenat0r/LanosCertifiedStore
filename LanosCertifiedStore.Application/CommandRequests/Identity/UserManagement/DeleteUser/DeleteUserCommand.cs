using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Identity.UserManagement.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Result<Unit>>;
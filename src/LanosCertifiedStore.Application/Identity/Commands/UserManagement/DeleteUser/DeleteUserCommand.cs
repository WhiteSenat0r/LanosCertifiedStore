using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Identity.Commands.UserManagement.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Result<Unit>>;
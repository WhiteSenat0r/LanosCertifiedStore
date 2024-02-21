using Domain.Shared;
using MediatR;

namespace Application.Commands.Identity.UserManagement.DeleteUser;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Result<Unit>>;
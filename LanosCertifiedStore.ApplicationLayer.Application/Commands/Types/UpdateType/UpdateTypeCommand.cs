using Domain.Shared;
using MediatR;

namespace Application.Commands.Types.UpdateType;

public sealed record UpdateTypeCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;
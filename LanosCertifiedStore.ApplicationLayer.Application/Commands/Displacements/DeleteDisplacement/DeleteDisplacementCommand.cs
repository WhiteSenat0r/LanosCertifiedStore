using Application.Core;
using MediatR;

namespace Application.Commands.Displacements.DeleteDisplacement;

public sealed record DeleteDisplacementCommand(Guid Id) : IRequest<Result<Unit>>;
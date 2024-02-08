using Application.Core;
using MediatR;

namespace Application.Commands.Displacements.DeleteDisplacement;

public sealed record DeleteDisplacementCommand(double Value) : IRequest<Result<Unit>>;
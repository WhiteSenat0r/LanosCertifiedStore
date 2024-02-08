using Application.Core;
using MediatR;

namespace Application.Commands.Displacements.CreateDisplacement;

public sealed record CreateDisplacementCommand(double Value) : IRequest<Result<Unit>>;
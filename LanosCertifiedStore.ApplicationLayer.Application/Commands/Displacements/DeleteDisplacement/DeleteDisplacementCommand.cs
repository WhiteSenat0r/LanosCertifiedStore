using Application.Core;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Displacements.DeleteDisplacement;

public sealed record DeleteDisplacementCommand(Guid Id) : IRequest<Result<Unit>>;
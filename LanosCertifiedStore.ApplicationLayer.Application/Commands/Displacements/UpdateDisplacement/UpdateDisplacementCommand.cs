using Application.Core;
using Application.Dtos.DisplacementDtos;
using MediatR;

namespace Application.Commands.Displacements.UpdateDisplacement;

public sealed record UpdateDisplacementCommand(UpdateDisplacementDto UpdateDisplacementDto)
    : IRequest<Result<Unit>>;
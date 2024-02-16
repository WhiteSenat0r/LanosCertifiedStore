using Application.Dtos.DisplacementDtos;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Displacements.UpdateDisplacement;

public sealed record UpdateDisplacementCommand(UpdateDisplacementDto UpdateDisplacementDto)
    : IRequest<Result<Unit>>;
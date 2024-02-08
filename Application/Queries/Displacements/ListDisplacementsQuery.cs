using Application.Core;
using Application.Dtos.DisplacementDtos;
using MediatR;

namespace Application.Queries.Displacements;

public sealed record ListDisplacementsQuery : IRequest<Result<IReadOnlyList<DisplacementDto>>>;
using Application.Dtos.ColorDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors;

public sealed record ListColorsQuery : IRequest<Result<IReadOnlyList<ColorDto>>>;
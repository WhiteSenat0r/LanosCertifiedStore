using Application.Core;
using Application.Dtos.ColorDtos;
using MediatR;

namespace Application.Queries.Colors;

public sealed record ListColorsQuery : IRequest<Result<IReadOnlyList<ColorDto>>>;
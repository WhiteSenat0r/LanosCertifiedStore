using Application.Dtos.ColorDtos;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors;

public sealed record ColorsQuery(VehicleColorFilteringRequestParameters RequestParameters) : IRequest<Result<IReadOnlyList<ColorDto>>>;
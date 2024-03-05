using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Colors;

public sealed record ColorsQuery(VehicleColorFilteringRequestParameters RequestParameters) :
    ListQueryBase<VehicleColor, VehicleColorFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<ColorDto>>>;
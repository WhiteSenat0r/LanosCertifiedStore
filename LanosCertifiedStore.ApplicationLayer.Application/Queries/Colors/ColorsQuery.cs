using Application.Core.Results;
using Application.Dtos.ColorDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes;
using MediatR;

namespace Application.Queries.Colors;

public sealed record ColorsQuery(VehicleColorFilteringRequestParameters RequestParameters) :
    ListQueryBase<VehicleColor, VehicleColorFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<ColorDto>>>;
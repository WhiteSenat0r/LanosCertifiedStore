using Application.Core.Results;
using Application.Dtos.VehicleDtos;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Vehicles.VehiclesQueryRelated;

public sealed record VehiclesQuery(VehicleFilteringRequestParameters RequestParameters)
    : IRequest<Result<PaginationResult<VehicleDto>>>;
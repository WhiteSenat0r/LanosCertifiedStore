using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.RequestParams;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

public sealed record TypesQuery(VehicleTypeFilteringRequestParameters RequestParameters) :
    ListQueryBase<VehicleType, VehicleTypeFilteringRequestParameters>(RequestParameters),
    IRequest<Result<PaginationResult<TypeDto>>>;
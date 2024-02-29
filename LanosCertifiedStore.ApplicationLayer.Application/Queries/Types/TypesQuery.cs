using Application.Dtos.TypeDtos;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types;

public sealed record TypesQuery(VehicleTypeFilteringRequestParameters RequestParameters)
    : IRequest<Result<IReadOnlyList<TypeDto>>>;
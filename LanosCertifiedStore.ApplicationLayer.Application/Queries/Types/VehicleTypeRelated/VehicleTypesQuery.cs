using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated;

public sealed record VehicleTypesQuery(IFilteringRequestParameters<VehicleType> RequestParameters) :
    ListQueryBase<VehicleType, IFilteringRequestParameters<VehicleType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleTypeDto>>>;
using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleEngineTypeRelated;

public sealed record VehicleEngineTypesQuery(IFilteringRequestParameters<VehicleEngineType> RequestParameters) :
    ListQueryBase<VehicleEngineType, IFilteringRequestParameters<VehicleEngineType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleEngineTypeDto>>>;
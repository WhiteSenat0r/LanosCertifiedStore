using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTypeRelated;

public sealed record VehicleTypesQuery(IFilteringRequestParameters<VehicleType> RequestParameters) :
    QueryBase<VehicleType, IFilteringRequestParameters<VehicleType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleTypeDto>>>;
using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated;

public sealed record VehicleBodyTypesQuery(IFilteringRequestParameters<VehicleBodyType> RequestParameters) :
    QueryBase<VehicleBodyType, IFilteringRequestParameters<VehicleBodyType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleBodyTypeDto>>>;
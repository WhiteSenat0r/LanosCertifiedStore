using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleBodyTypeRelated;

public sealed record VehicleBodyTypesQuery(IFilteringRequestParameters<VehicleBodyType> RequestParameters) :
    ListQueryBase<VehicleBodyType, IFilteringRequestParameters<VehicleBodyType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleBodyTypeDto>>>;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated;

public sealed record VehicleDrivetrainTypesQuery(
    IFilteringRequestParameters<VehicleDrivetrainType> RequestParameters) :
    ListQueryBase<VehicleDrivetrainType, IFilteringRequestParameters<VehicleDrivetrainType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleDrivetrainTypeDto>>>;
using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Models.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleDrivetrainTypeRelated;

public sealed record VehicleDrivetrainTypesQuery(
    IFilteringRequestParameters<VehicleDrivetrainType> RequestParameters) :
    ListQueryBase<VehicleDrivetrainType, IFilteringRequestParameters<VehicleDrivetrainType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleDrivetrainTypeDto>>>;
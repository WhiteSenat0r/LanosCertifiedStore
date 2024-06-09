using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated;

public sealed record VehicleTransmissionTypesQuery(
    IFilteringRequestParameters<VehicleTransmissionType> RequestParameters) :
    ListQueryBase<VehicleTransmissionType, IFilteringRequestParameters<VehicleTransmissionType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleTransmissionTypeDto>>>;
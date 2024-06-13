﻿using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated;

public sealed record VehicleTransmissionTypesQuery(
    IFilteringRequestParameters<VehicleTransmissionType> RequestParameters) :
    ListQueryBase<VehicleTransmissionType, IFilteringRequestParameters<VehicleTransmissionType>>(RequestParameters),
    IRequest<Result<PaginationResult<VehicleTransmissionTypeDto>>>;
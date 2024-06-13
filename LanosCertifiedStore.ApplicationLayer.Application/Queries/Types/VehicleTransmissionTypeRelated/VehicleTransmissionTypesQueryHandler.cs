﻿using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using Application.Shared;
using AutoMapper;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using MediatR;

namespace Application.Queries.Types.VehicleTransmissionTypeRelated;

internal sealed class VehicleTransmissionTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleTransmissionType,
        IFilteringRequestParameters<VehicleTransmissionType>,
        VehicleTransmissionTypeDto>(unitOfWork, mapper),
    IRequestHandler<VehicleTransmissionTypesQuery, Result<PaginationResult<VehicleTransmissionTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleTransmissionTypeDto>>> Handle(VehicleTransmissionTypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}
﻿using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Queries.Common.QueryRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes.TypeRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Types.VehicleEngineTypeRelated;

internal sealed class VehicleEngineTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    ListQueryHandlerBase<VehicleEngineType, IFilteringRequestParameters<VehicleEngineType>, VehicleEngineTypeDto>(
        unitOfWork, mapper),
    IRequestHandler<VehicleEngineTypesQuery, Result<PaginationResult<VehicleEngineTypeDto>>>
{
    public Task<Result<PaginationResult<VehicleEngineTypeDto>>> Handle(VehicleEngineTypesQuery request,
        CancellationToken cancellationToken) =>
        base.Handle(request, cancellationToken);
}
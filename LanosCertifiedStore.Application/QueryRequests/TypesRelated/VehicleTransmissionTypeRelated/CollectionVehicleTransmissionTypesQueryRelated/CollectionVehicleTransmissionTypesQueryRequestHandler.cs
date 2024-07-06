﻿using Application.Contracts.ServicesRelated;
using Application.Core.Results;
using Application.Dtos.TypeDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.TypesRelated.VehicleTransmissionTypeRelated
    .CollectionVehicleTransmissionTypesQueryRelated;

internal sealed class CollectionVehicleTransmissionTypesQueryRequestHandler(
    IVehicleTransmissionTypeService vehicleTransmissionTypeService) :
    IRequestHandler<
        CollectionVehicleTransmissionTypesQueryRequest,
        Result<PaginationResult<VehicleTransmissionTypeDto>>>
{
    public async Task<Result<PaginationResult<VehicleTransmissionTypeDto>>> Handle(
        CollectionVehicleTransmissionTypesQueryRequest request, CancellationToken cancellationToken)
    {
        var vehicleDriveTrainTypes = await vehicleTransmissionTypeService
            .GetVehicleTransmissionTypeCollection(request, cancellationToken);

        var paginationResult = new PaginationResult<VehicleTransmissionTypeDto>(
            vehicleDriveTrainTypes,
            request.FilteringParameters.PageIndex);

        return Result<PaginationResult<VehicleTransmissionTypeDto>>.Success(paginationResult);
    }
}
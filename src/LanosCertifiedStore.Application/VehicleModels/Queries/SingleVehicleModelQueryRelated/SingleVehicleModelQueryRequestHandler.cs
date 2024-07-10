﻿using Application.Shared.ResultRelated;
using Application.VehicleModels.Dtos;
using MediatR;

namespace Application.VehicleModels.Queries.SingleVehicleModelQueryRelated;

internal sealed class SingleVehicleModelQueryRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<SingleVehicleModelQueryRequest, Result<SingleVehicleModelDto>>
{
    public async Task<Result<SingleVehicleModelDto>> Handle(
        SingleVehicleModelQueryRequest request, CancellationToken cancellationToken)
    {
        var brand = await vehicleModelService.GetSingleVehicleModel(request, cancellationToken);

        return brand is null
            ? Result<SingleVehicleModelDto>.Failure(Error.NotFound(request.ItemId))
            : Result<SingleVehicleModelDto>.Success(brand);
    }
}

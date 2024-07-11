﻿using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;

internal sealed class UpdateVehicleBrandCommandRequestHandler(IVehicleBrandService brandService)
    : IRequestHandler<UpdateVehicleBrandCommandRequest, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleBrandCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await brandService.UpdateVehicleBrand(request, cancellationToken);
            return Result<Unit>.Success(Unit.Value);
        }
        catch (KeyNotFoundException)
        {
            return Result<Unit>.Failure(Error.NotFound(request.Id));
        }
    }
}
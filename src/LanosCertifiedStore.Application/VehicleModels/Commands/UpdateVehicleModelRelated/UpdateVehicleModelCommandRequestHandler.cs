using Application.Shared.ResultRelated;
using MediatR;

namespace Application.VehicleModels.Commands.UpdateVehicleModelRelated;

internal sealed class UpdateVehicleModelCommandRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<UpdateVehicleModelCommandRequest, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(
        UpdateVehicleModelCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await vehicleModelService.UpdateVehicleModel(request, cancellationToken);
        
            return Result<Unit>.Success(Unit.Value);
        }
        catch (KeyNotFoundException e)
        {
            return Result<Unit>.Failure(Error.NotFound(e.Message));
        }
    }
}
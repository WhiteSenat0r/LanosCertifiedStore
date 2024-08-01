using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleModels.Commands.UpdateVehicleModelRelated;

internal sealed class UpdateVehicleModelCommandRequestHandler(IVehicleModelService vehicleModelService) : 
    IRequestHandler<UpdateVehicleModelCommandRequest, Result>
{
    public async Task<Result> Handle(
        UpdateVehicleModelCommandRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            await vehicleModelService.UpdateVehicleModel(request, cancellationToken);

            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException e)
        {
            return Result<Unit>.Failure(Error.NotFound(e.Message));
        }
    }
}
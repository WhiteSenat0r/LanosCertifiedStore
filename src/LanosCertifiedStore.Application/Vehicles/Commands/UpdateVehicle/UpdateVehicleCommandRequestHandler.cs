using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(IVehicleService vehicleService)
    : IRequestHandler<UpdateVehicleCommandRequest, Result>
{
    public async Task<Result> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await vehicleService.UpdateVehicle(request, cancellationToken);
            return Result.Create(Error.None);
        }
        catch (KeyNotFoundException)
        {
            return Result.Create(Error.NotFound(request.Id));
        }
    }
}
using LanosCertifiedStore.Application.Images;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles.Queries.SingleVehicleQueryRequestRelated;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LanosCertifiedStore.Application.Vehicles.Commands.DeleteVehicleCommandRequestRelated;

internal sealed class DeleteVehicleCommandRequestHandler(
    ILogger<DeleteVehicleCommandRequestHandler> logger,
    IVehicleService vehicleService,
    IImageService imageService) : IRequestHandler<DeleteVehicleCommandRequest, Result>
{
    public async Task<Result> Handle(DeleteVehicleCommandRequest request, CancellationToken cancellationToken)
    {
        var vehicle = await vehicleService.GetVehicle(new SingleVehicleQueryRequest(request.Id), cancellationToken);

        if (vehicle is null)
        {
            return Result.Create(Error.NotFound(request.Id));
        }

        await vehicleService.DeleteVehicle(request.Id, cancellationToken);

        if (vehicle.Images is null || !vehicle.Images.Any())
        {
            return Result.Create(Error.None);
        }

        var tasks = vehicle.Images.Select(i => imageService.TryDeletePhotoAsync(i.CloudImageId));

        await Task.WhenAll(tasks);

        return Result.Create(Error.None);
    }
}
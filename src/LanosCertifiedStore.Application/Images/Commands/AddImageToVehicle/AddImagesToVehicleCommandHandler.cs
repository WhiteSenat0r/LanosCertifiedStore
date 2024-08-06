using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Vehicles;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Images.Commands.AddImageToVehicle;

internal sealed class AddImagesToVehicleCommandHandler(
    IVehicleService vehicleService,
    IImageService imageService) : IRequestHandler<AddImagesToVehicleCommandRequest, Result>
{
    private const string PathTemplate = "LanosCertifiedStore/Vehicles";

    public async Task<Result> Handle(AddImagesToVehicleCommandRequest request, CancellationToken cancellationToken)
    {
        if (!await vehicleService.ExistsById(request.VehicleId, cancellationToken))
        {
            return Result.Create(Error.NotFound(request.VehicleId));
        }

        var tasks = request.Images.Select(image => imageService.UploadImageAsync(image, PathTemplate));

        var imageResults = await Task.WhenAll(tasks);

        var successfulUploads = new List<VehicleImage>();
        var failedUploads = new List<ImageResult>();

        foreach (var imageResult in imageResults)
        {
            if (imageResult.IsUploadedSuccessfully)
            {
                successfulUploads.Add(new VehicleImage(
                    request.VehicleId,
                    imageResult.ImageId!,
                    imageResult.ImageUrl!,
                    false));
            }
            else
            {
                failedUploads.Add(imageResult);
            }
        }

        if (failedUploads.Count > 0)
        {
            return Result.Create(ImageUploadErrors.UploadError(failedUploads));
        }

        if (successfulUploads.Count > 0)
        {
            await vehicleService.AddImagesToVehicle(request.VehicleId, successfulUploads, cancellationToken);
        }

        return Result.Create(Error.None);
    }
}
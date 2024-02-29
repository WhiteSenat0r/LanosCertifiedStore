using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.AddImageToVehicle;

internal sealed class AddImageToVehicleCommandHandler(
    IUnitOfWork unitOfWork,
    IImageService imageService)
    : IRequestHandler<AddImageToVehicleCommand, Result<Unit>>
{
    private const string PathTemplate = "LanosCertifiedStore/Vehicles";

    public async Task<Result<Unit>> Handle(AddImageToVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);

        if (vehicle is null)
            return Result<Unit>.Failure(Error.NotFound);

        var imageResult = await imageService.UploadImageAsync(request.Image, PathTemplate);

        if (!imageResult.IsUploadedSuccessfully)
            return Result<Unit>.Failure(new Error("ImageUploadError", imageResult.ErrorMessage!));

        var vehicleImage = new VehicleImage(vehicle, imageResult.ImageId!, imageResult.ImageUrl!);

        try
        {
            await unitOfWork.RetrieveRepository<VehicleImage>().AddNewEntityAsync(vehicleImage);
            
            var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure(new Error("ImageUpload", "Failed to upload image to database!"));
        }
        catch (Exception e)
        {
            await imageService.TryDeletePhotoAsync(imageResult.ImageId!);
            return Result<Unit>.Failure(new Error("ImageUpload", e.Message));
        }
    }
}
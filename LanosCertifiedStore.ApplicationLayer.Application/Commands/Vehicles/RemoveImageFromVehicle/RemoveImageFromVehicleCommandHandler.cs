using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.RemoveImageFromVehicle;

internal sealed class RemoveImageFromVehicleCommandHandler(
    IUnitOfWork unitOfWork,
    IImageService imageService)
    : IRequestHandler<RemoveImageFromVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(RemoveImageFromVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);

        if (vehicle is null)
            return Result<Unit>.Failure(Error.NotFound);

        var image = await unitOfWork.RetrieveRepository<VehicleImage>().GetEntityByIdAsync(request.ImageId);

        if (image is null)
            return Result<Unit>.Failure(Error.NotFound);

        if (!vehicle.Images.Select(x => x.Id).Contains(image.Id))
            return Result<Unit>.Failure(new Error("DeleteImage", "This image does not belong to this vehicle!"));
        
        if (image.IsMainImage)
            return Result<Unit>.Failure(new Error("DeleteImage", "Main image can't be deleted!"));

        await unitOfWork.RetrieveRepository<VehicleImage>().RemoveExistingEntityAsync(image.Id);
        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!result)
            return Result<Unit>.Failure(new Error("DeleteImage", "Failed to delete image from database"));

        var deleteImageFromCloudResult = await imageService.TryDeletePhotoAsync(image.CloudImageId);


        return deleteImageFromCloudResult
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("DeleteImage", "Failed to delete image from cloud"));
    }
}
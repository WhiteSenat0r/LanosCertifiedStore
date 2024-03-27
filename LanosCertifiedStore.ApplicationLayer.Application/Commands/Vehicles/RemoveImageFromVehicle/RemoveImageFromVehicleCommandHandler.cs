using Application.Commands.Vehicles.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.RemoveImageFromVehicle;

internal sealed class RemoveImageFromVehicleCommandHandler : 
    ActionVehicleImageCommandHandlerBase, IRequestHandler<RemoveImageFromVehicleCommand, Result<Unit>>
{
    private readonly IImageService _imageService;

    public RemoveImageFromVehicleCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        : base(unitOfWork)
    {
        _imageService = imageService;
        PossibleErrors =
        [
            new Error("DeleteVehicleImageError", "Vehicle image removal was not successful!"),
            new Error("DeleteVehicleImageError", "Error occured during the vehicle image removal!"),
            new Error("DeleteVehicleImageError", "This image does not belong to this vehicle!"),
            new Error("DeleteVehicleImageError", "Vehicle's main image can't be deleted!"),
            new Error("DeleteVehicleImageError", "Failed to delete vehicle's image from the cloud!")
        ];
    }

    public async Task<Result<Unit>> Handle(RemoveImageFromVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await GetRequiredRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);

        if (vehicle is null) return Result<Unit>.Failure(Error.NotFound);

        var image = await GetRequiredRepository<VehicleImage>().GetEntityByIdAsync(request.ImageId);

        var imageCheckResult = GetImageCheckResult(image, vehicle);

        if (!imageCheckResult.IsSuccess) return imageCheckResult;

        await GetRequiredRepository<VehicleImage>().RemoveExistingEntityAsync(image!.Id);
        
        var result = await TrySaveChanges(cancellationToken);

        if (!result.IsSuccess) return result;

        var deleteImageFromCloudResult = await _imageService.TryDeletePhotoAsync(image.CloudImageId);
        
        return deleteImageFromCloudResult
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(PossibleErrors[4]);
    }
}
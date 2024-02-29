using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.SetVehicleMainImage;

internal sealed class SetVehicleMainImageCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<SetVehicleMainImageCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(SetVehicleMainImageCommand request, CancellationToken cancellationToken)
    {
        var imageRepository = unitOfWork.RetrieveRepository<VehicleImage>();

        var vehicle = await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);

        if (vehicle is null)
            return Result<Unit>.Failure(Error.NotFound);

        var image = await imageRepository.GetEntityByIdAsync(request.ImageId);
        if (image is null)
            return Result<Unit>.Failure(Error.NotFound);

        if (!vehicle.Images.Select(x => x.Id).Contains(image.Id))
            return Result<Unit>.Failure(new Error("SetMainImage", "This image does not belong to this vehicle!"));

        if (image.IsMainImage)
            return Result<Unit>.Failure(new Error("SetMainImage", "This image is already main!"));

        var mainImage = await imageRepository.GetEntityByIdAsync(vehicle.Images.Single(x => x.IsMainImage).Id);
        
        mainImage!.Vehicle = vehicle;
        mainImage.IsMainImage = false;
        
        imageRepository.UpdateExistingEntity(mainImage);

        image.Vehicle = vehicle;
        image.IsMainImage = true;
        imageRepository.UpdateExistingEntity(image);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("SetMainImage", "Failed to set image as main."));
    }
}
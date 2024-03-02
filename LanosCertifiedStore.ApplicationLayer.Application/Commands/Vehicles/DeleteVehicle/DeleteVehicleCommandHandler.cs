using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.DeleteVehicle;

internal sealed class DeleteVehicleCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    : IRequestHandler<DeleteVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedEntity =
            await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.Id);

        if (updatedEntity is null)
            return Result<Unit>.Failure(Error.NotFound);

        foreach (var image in updatedEntity.Images)
            await imageService.TryDeletePhotoAsync(image.CloudImageId);
        
        await unitOfWork.RetrieveRepository<Vehicle>().RemoveExistingEntityAsync(request.Id);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("DeleteError", "Failed to delete a vehicle!"));
    }
}
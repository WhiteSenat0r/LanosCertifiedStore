using Application.Commands.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.DeleteVehicle;

internal sealed class DeleteVehicleCommandHandler 
    : CommandHandlerBase<Unit>, IRequestHandler<DeleteVehicleCommand, Result<Unit>>
{
    private readonly IImageService _imageService;

    public DeleteVehicleCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
        : base(unitOfWork)
    {
        _imageService = imageService;
        PossibleErrors = new[]
        {
            new Error("DeleteVehicleError", "Vehicle removal was not successful!"),
            new Error("DeleteVehicleError", "Error occured during the vehicle removal!")
        };
    }

    public async Task<Result<Unit>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedEntity = await GetRequiredRepository<Vehicle>().GetEntityByIdAsync(request.Id);

        if (updatedEntity is null) return Result<Unit>.Failure(Error.NotFound);
        
        await GetRequiredRepository<Vehicle>().RemoveExistingEntityAsync(request.Id);

        var result = await TrySaveChanges(cancellationToken);
        
        return result.IsSuccess 
            ? await PerformExternalDataRemoval(updatedEntity, result)
            : result;
    }

    private async Task<Result<Unit>> PerformExternalDataRemoval(Vehicle entity, Result<Unit> result)
    {
        await RemoveImagesFromCloud(entity);
        
        return result;
    }
    
    private async Task RemoveImagesFromCloud(Vehicle entity)
    {
        foreach (var image in entity.Images)
            await _imageService.TryDeletePhotoAsync(image.CloudImageId);
    }
}
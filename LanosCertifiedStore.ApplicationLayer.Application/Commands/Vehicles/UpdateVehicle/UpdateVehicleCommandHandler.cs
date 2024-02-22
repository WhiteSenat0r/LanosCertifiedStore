using Application.Commands.Vehicles.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,
    IImageService imageService) : ActionVehicleCommandHandlerBase, IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    private Vehicle? _updatedEntity;
    
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (IsPresentMainImageFlagConflict(request))
                return Result<Unit>.Failure(new Error(
                    "UpdateError", "Failed to update a vehicle due to the main image flag conflict!"));
            
            _updatedEntity =
                await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.UpdateVehicleDto.Id);

            if (_updatedEntity is null)
                return Result<Unit>.Failure(Error.NotFound);

            var requestVehicleResult = 
                await CreateVehicleBaseInstance<UpdateVehicleCommand, UpdateVehicleDto>(mapper, unitOfWork, request);

            if (!requestVehicleResult.IsSuccess)
                return Result<Unit>.Failure(requestVehicleResult.Error!);
        
            await TrySetupNewVehicleData(request, requestVehicleResult);

            var result = await GetVehicleUpdateResult(_updatedEntity!, cancellationToken);

            return result
                ? Result<Unit>.Success(Unit.Value)
                : throw new Exception("Failed to update a vehicle!");
        }
        catch (Exception e)
        {
            await imageService.TryRollbackImageUploadAsync();
            return Result<Unit>.Failure(new Error("UpdateError", "Failed to update a vehicle!"));
        }
    }

    private async Task TrySetupNewVehicleData(UpdateVehicleCommand request, Result<Vehicle> requestVehicleResult)
    {
        await TryRemoveImagesAndUpdateIsMainFlags(request, requestVehicleResult);
        await TryUploadNewImages(request);
        await TryUpdatePrice(request);
        mapper.Map(requestVehicleResult.Value!, _updatedEntity!);
    }
    
    private async Task TryRemoveImagesAndUpdateIsMainFlags(
        UpdateVehicleCommand request, Result<Vehicle> requestVehicleResult)
    {
        var removedImages = GetRemovedImages(_updatedEntity!, requestVehicleResult);

        await TryRemoveImagesFromVehicle(removedImages, _updatedEntity!);
        TrySetUploadedImageAsMain(request, _updatedEntity!);
    }

    private async Task TryUploadNewImages(UpdateVehicleCommand request)
    {
        var uploadedImagesResult = await TryAddImagesToCloudinary(imageService, request, _updatedEntity!.Id);

        if (uploadedImagesResult.IsSuccess)
        {
            foreach (var image in uploadedImagesResult.Value!) 
                await unitOfWork.RetrieveRepository<VehicleImage>().AddNewEntityAsync(image);
        }
    }
    
    private async Task TryUpdatePrice(UpdateVehicleCommand request)
    {
        if (IsAlteredPriceValue(request, _updatedEntity!))
            await InitializeNewPrice(request, _updatedEntity!);
    }

    private static bool IsPresentMainImageFlagConflict(UpdateVehicleCommand request)
    {
        return request.MainImageId.HasValue &&
               (!string.IsNullOrEmpty(request.MainImageName) || !string.IsNullOrWhiteSpace(request.MainImageName));
    }

    private async Task<bool> GetVehicleUpdateResult(
        Vehicle vehicleToUpdate, CancellationToken cancellationToken)
    {
        unitOfWork.RetrieveRepository<Vehicle>().UpdateExistingEntity(vehicleToUpdate);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!result) await imageService.TryRollbackImageUploadAsync();
        
        return result;
    }

    private void TrySetUploadedImageAsMain(UpdateVehicleCommand request, Vehicle vehicleToUpdate)
    {
        if (!request.MainImageId.HasValue) return;

        foreach (var image in vehicleToUpdate.Images) image.IsMainImage = false;
        
        var mainImage = vehicleToUpdate.Images.Single(image => image.Id.Equals(request.MainImageId.Value));

        mainImage.IsMainImage = true;

        foreach (var image in vehicleToUpdate.Images) 
            unitOfWork.RetrieveRepository<VehicleImage>().UpdateExistingEntity(image);
        
        unitOfWork.ClearChangeTrackerData();
    }

    private async Task TryRemoveImagesFromVehicle(
        IEnumerable<VehicleImage> removedImages,
        Vehicle vehicleToUpdate)
    {
        if (!removedImages.Any()) return;

        var imageRepository = unitOfWork.RetrieveRepository<VehicleImage>();
        
        foreach (var removedImage in removedImages)
        {
            var updatedVehicleRemovedImage = vehicleToUpdate.Images.Single(
                image => image.Id.Equals(removedImage.Id));

            vehicleToUpdate.Images.Remove(updatedVehicleRemovedImage);
            await imageRepository.RemoveExistingEntity(updatedVehicleRemovedImage.Id);
            await imageService.TryDeletePhotoAsync(removedImage.CloudImageId);
        }

        await unitOfWork.SaveChangesAsync();
        
        unitOfWork.ClearChangeTrackerData();
    }

    private IEnumerable<VehicleImage> GetRemovedImages(
        Vehicle vehicleToUpdate, Result<Vehicle> requestVehicleResult)
    {
        var removedImages = new List<VehicleImage>();
        
        foreach (var image in vehicleToUpdate.Images)
        {
            var requestVehicleImage = requestVehicleResult.Value!.Images.SingleOrDefault(
                requestImage => requestImage.Id.Equals(image.Id));
            
            if (requestVehicleImage is null) removedImages.Add(image);
        }

        return removedImages;
    }

    private async Task InitializeNewPrice(UpdateVehicleCommand request, Vehicle updatedVehicle)
    {
        var newPrice = new VehiclePrice(updatedVehicle, request.UpdateVehicleDto.Price);

        await unitOfWork.RetrieveRepository<VehiclePrice>().AddNewEntityAsync(newPrice);
    }

    private bool IsAlteredPriceValue(UpdateVehicleCommand request, Vehicle updatedVehicle) =>
        !updatedVehicle.Prices.MaxBy(p => p.IssueDate)!.Value.Equals(request.UpdateVehicleDto.Price);
}
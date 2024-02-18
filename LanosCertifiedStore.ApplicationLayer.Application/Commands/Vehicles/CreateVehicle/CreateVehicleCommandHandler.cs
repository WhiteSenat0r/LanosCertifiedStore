using Application.Commands.Vehicles.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Application.Core.Results;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IUnitOfWork unitOfWork, IImageService imageService)
    : ActionVehicleCommandBase, IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var vehicleInstantiationResult = await CreateVehicleBaseInstance(request, unitOfWork);

            if (!vehicleInstantiationResult.IsSuccess)
                return Result<Unit>.Failure(vehicleInstantiationResult.Error!);

            var imagesUploadResult = await TryAddImagesToStorage(imageService, request);

            if (!imagesUploadResult.IsSuccess)
                return Result<Unit>.Failure(imagesUploadResult.Error!);

            (vehicleInstantiationResult.Value!.Images as List<VehicleImage>)!.AddRange(imagesUploadResult.Value!);
            await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleInstantiationResult.Value!);
            var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            return saveResult 
                ? Result<Unit>.Success(Unit.Value)
                : throw new Exception("Saving changes has failed!");
        }
        catch (Exception e)
        {
            return Result<Unit>.Failure(new Error("CreateError", "Failed to create a vehicle!"));
        }
    }
    
    private async Task<Result<IEnumerable<VehicleImage>>> TryAddImagesToStorage(
        IImageService imageService, CreateVehicleCommand request)
    {
        if (request.Images.Count.Equals(0))
            return Result<IEnumerable<VehicleImage>>.Failure(new Error("CreateError",
                "Image collection has no images to upload!"));
    
        var uploadSummary = await TryUploadImagesToCloudinary(
            imageService, request.Images, request.MainImageName);

        if (!uploadSummary.IsSuccess)
            return Result<IEnumerable<VehicleImage>>.Failure(uploadSummary.Error!);
        
        var uploadedImages = uploadSummary.Value!.Select(summary =>
            new VehicleImage(null!, summary.Key.ImageId!, summary.Key.ImageUrl!, summary.Value));

        return Result<IEnumerable<VehicleImage>>.Success(uploadedImages);
    }

    private async Task<Result<IDictionary<ImageResult, bool>>> TryUploadImagesToCloudinary(
        IImageService service, IEnumerable<IFormFile> images, string mainImageName)
    {
        var summary = new Dictionary<ImageResult, bool>();
        
        foreach (var image in images)
        {
            var uploadResult = await service.UploadImageAsync(image, PathTemplate);

            if (mainImageName.Equals(image.FileName))
            {
                summary.Add(uploadResult, true);
                continue;
            }
            
            summary.Add(uploadResult, false);
        }
    
        if (summary.All(pair => pair.Key.IsUploadedSuccessfully)) 
            return Result<IDictionary<ImageResult, bool>>.Success(summary);
        
        await imageService.TryRollbackImageUploadAsync();
                
        return Result<IDictionary<ImageResult, bool>>.Failure(
            new Error("CreateError", "Service was not able to upload the image(s)!"));
    }
}
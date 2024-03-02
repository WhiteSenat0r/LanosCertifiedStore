﻿using Application.Commands.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.AddImageToVehicle;

internal sealed class AddImageToVehicleCommandHandler : 
    CommandHandlerBase<Unit>, IRequestHandler<AddImageToVehicleCommand, Result<Unit>>
{
    private const string PathTemplate = "LanosCertifiedStore/Vehicles";
    
    private readonly IImageService _imageService;

    public AddImageToVehicleCommandHandler(IUnitOfWork unitOfWork, IImageService imageService) : base(unitOfWork)
    {
        _imageService = imageService;
        PossibleErrors = new[]
        {
            new Error("VehicleImageUploadError", "Vehicle image upload was not successful!"),
            new Error("VehicleImageUploadError", "Error occured during the vehicle image upload!")
        };
    }

    public async Task<Result<Unit>> Handle(AddImageToVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await GetRequiredRepository<Vehicle>().GetEntityByIdAsync(request.VehicleId);

        if (vehicle is null) return Result<Unit>.Failure(Error.NotFound);

        var imageResult = await _imageService.UploadImageAsync(request.Image, PathTemplate);

        if (!imageResult.IsUploadedSuccessfully)
            return Result<Unit>.Failure(new Error("VehicleImageUploadError", imageResult.ErrorMessage!));

        var vehicleImage = new VehicleImage(vehicle, imageResult.ImageId!, imageResult.ImageUrl!);

        await GetRequiredRepository<VehicleImage>().AddNewEntityAsync(vehicleImage);
        
        var result = await TrySaveChanges(cancellationToken);
        
        if (!result.IsSuccess)
            await _imageService.TryDeletePhotoAsync(imageResult.ImageId!);

        return result;
    }
}
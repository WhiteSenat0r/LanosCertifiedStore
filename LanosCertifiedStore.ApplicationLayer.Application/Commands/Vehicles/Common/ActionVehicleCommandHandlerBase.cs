using Application.Commands.Vehicles.CreateVehicle;
using Application.Commands.Vehicles.UpdateVehicle;
using Application.Contracts.ServicesRelated.ImageService;
using Application.Core.Results;
using Application.Dtos.ImageDtos;
using Application.Dtos.VehicleDtos;
using Application.Dtos.VehicleDtos.Common;
using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Commands.Vehicles.Common;

internal abstract class ActionVehicleCommandHandlerBase
{
    // private const string PathTemplate = "LanosCertifiedStore/Vehicles";
    
    private protected async Task<Result<Vehicle>> CreateVehicleBaseInstance<TDtoType>(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IActionVehicleCommandBase request) 
    {
        var vehicleModel = await GetAspectDataAsync<VehicleModel>(unitOfWork, request.ModelId);
        if (vehicleModel is null) return GetFailureResult("Model");

        var vehicleBrand = await GetAspectDataAsync<VehicleBrand>(unitOfWork, vehicleModel.Brand.Id);
        if (vehicleBrand is null) return GetFailureResult("Brand");

        var vehicleColor = await GetAspectDataAsync<VehicleColor>(unitOfWork, request.ColorId);
        if (vehicleColor is null) return GetFailureResult("Color");

        var vehicleType = await GetAspectDataAsync<VehicleType>(unitOfWork, request.TypeId);
        if (vehicleType is null) return GetFailureResult("Type");

        var vehicle = InstantiateVehicleObject(
            mapper, vehicleBrand, vehicleModel, vehicleColor, vehicleType, request);

        return Result<Vehicle>.Success(vehicle);
    }

    // private protected async Task<Result<IEnumerable<VehicleImage>>> TryAddImagesToCloudinary<TCommand>(
    //     IImageService imageService, TCommand request, Guid? vehicleId = null)
    //     where TCommand : IActionVehicleCommandBase
    // {
    //     if (request is CreateVehicleCommand { Images.Count: 0 })
    //         return Result<IEnumerable<VehicleImage>>.Failure(new Error("CreateError",
    //             "Image collection has no images to upload!"));
    //     
    //     if (request is UpdateVehicleCommand { Images.Count: 0 })
    //         return Result<IEnumerable<VehicleImage>>.Failure(
    //             new Error("EmptyUpdateUpload", "Nothing to upload!"));
    //
    //     var uploadSummary = await TryUploadImagesToCloudinary(
    //         imageService, request.Images!, request.MainImageName!);
    //
    //     if (!uploadSummary.IsSuccess)
    //         return Result<IEnumerable<VehicleImage>>.Failure(uploadSummary.Error!);
    //     
    //     var uploadedImages = uploadSummary.Value!.Select(summary =>
    //         vehicleId.HasValue
    //             ? new VehicleImage(new Vehicle { Id = vehicleId.Value },
    //                 summary.Key.ImageId!, summary.Key.ImageUrl!, summary.Value)
    //             : new VehicleImage(null!, summary.Key.ImageId!, summary.Key.ImageUrl!, summary.Value));
    //
    //     return Result<IEnumerable<VehicleImage>>.Success(uploadedImages);
    // }

    // private async Task<Result<IDictionary<ImageResult, bool>>> TryUploadImagesToCloudinary(
    //     IImageService service, IEnumerable<IFormFile> images, string mainImageName)
    // {
    //     var summary = new Dictionary<ImageResult, bool>();
    //     
    //     foreach (var image in images)
    //     {
    //         var uploadResult = await service.UploadImageAsync(image, PathTemplate);
    //
    //         if (!string.IsNullOrEmpty(mainImageName) && mainImageName.Equals(image.FileName))
    //         {
    //             summary.Add(uploadResult, true);
    //             continue;
    //         }
    //         
    //         summary.Add(uploadResult, false);
    //     }
    //
    //     if (summary.All(pair => pair.Key.IsUploadedSuccessfully)) 
    //         return Result<IDictionary<ImageResult, bool>>.Success(summary);
    //     
    //     await service.TryRollbackImageUploadAsync();
    //             
    //     return Result<IDictionary<ImageResult, bool>>.Failure(
    //         new Error("CreateError", "Service was not able to upload the image(s)!"));
    // }
    
    private Vehicle InstantiateVehicleObject(
        IMapper mapper,
        VehicleBrand vehicleBrand,
        VehicleModel vehicleModel,
        VehicleColor vehicleColor,
        VehicleType vehicleType,
        IActionVehicleCommandBase vehicleData)
    {
        if (vehicleData is CreateVehicleCommand createVehicleCommand)
            return new Vehicle(
                brand: vehicleBrand,
                model: vehicleModel,
                color: vehicleColor,
                type: vehicleType,
                price: createVehicleCommand.Price, 
                displacement: createVehicleCommand.Displacement,
                description: createVehicleCommand.Description
            );

        return new Vehicle(
            brand: vehicleBrand,
            model: vehicleModel,
            color: vehicleColor,
            type: vehicleType,
            price: vehicleData.Price,
            displacement: vehicleData.Displacement,
            description: vehicleData.Description
        );
    }

    private TDtoType GetActionVehicleDto<TCommand, TDtoType>(TCommand request)
    {
        var requestParamsProperty = request!.GetType().GetProperties().FirstOrDefault(
            p => p.PropertyType == typeof(TDtoType));
        
        return (TDtoType)requestParamsProperty?.GetValue(request)!;
    }
    
    private Task<TAspect?> GetAspectDataAsync<TAspect>(IUnitOfWork unitOfWork, Guid id) 
        where TAspect : IIdentifiable<Guid> => 
        unitOfWork.RetrieveRepository<TAspect>().GetEntityByIdAsync(id);

    private Result<Vehicle> GetFailureResult(string aspect) =>
        Result<Vehicle>.Failure(
            new Error("NotFound", $"Such {aspect.ToLower()} doesn't exists!"));
}
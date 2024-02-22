using Application.Commands.Vehicles.Common;
using Application.Contracts.ServicesRelated.ImageService;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IImageService imageService)
    : ActionVehicleCommandHandlerBase, IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var vehicleInstantiationResult = 
                await CreateVehicleBaseInstance<CreateVehicleCommand, CreateVehicleDto>(
                    mapper, unitOfWork, request);

            if (!vehicleInstantiationResult.IsSuccess)
                return Result<Unit>.Failure(vehicleInstantiationResult.Error!);

            var imagesUploadResult = await TryAddImagesToCloudinary(imageService, request);

            if (!imagesUploadResult.IsSuccess)
                return Result<Unit>.Failure(imagesUploadResult.Error!);

            var saveResult = await GetAddedVehicleSavingResult(
                vehicleInstantiationResult, imagesUploadResult, cancellationToken);

            return saveResult 
                ? Result<Unit>.Success(Unit.Value)
                : throw new Exception("Saving changes has failed!");
        }
        catch (Exception e)
        {
            return Result<Unit>.Failure(new Error("CreateError", "Failed to create a vehicle!"));
        }
    }

    private async Task<bool> GetAddedVehicleSavingResult(
        Result<Vehicle> vehicleInstantiationResult,
        Result<IEnumerable<VehicleImage>> imagesUploadResult,
        CancellationToken cancellationToken)
    {
        (vehicleInstantiationResult.Value!.Images as List<VehicleImage>)!.AddRange(imagesUploadResult.Value!);
        await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleInstantiationResult.Value!);
        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        
        if (!saveResult) await imageService.TryRollbackImageUploadAsync();
        
        return saveResult;
    }
}
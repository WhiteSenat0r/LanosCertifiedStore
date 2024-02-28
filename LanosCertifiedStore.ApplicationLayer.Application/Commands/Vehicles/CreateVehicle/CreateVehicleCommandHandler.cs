using Application.Commands.Vehicles.Common;
using Application.Dtos.VehicleDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : ActionVehicleCommandHandlerBase, IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleInstantiationResult =
            await CreateVehicleBaseInstance<CreateVehicleDto>(
                mapper, unitOfWork, request);

        if (!vehicleInstantiationResult.IsSuccess)
            return Result<Unit>.Failure(vehicleInstantiationResult.Error!);

        // var imagesUploadResult = await TryAddImagesToCloudinary(imageService, request);
        //
        // if (!imagesUploadResult.IsSuccess)
        //     return Result<Unit>.Failure(imagesUploadResult.Error!);

        var saveResult = await GetAddedVehicleSavingResult(
            vehicleInstantiationResult, cancellationToken);

        return saveResult
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("CreateError", "Failed to create a vehicle!"));
    }

    private async Task<bool> GetAddedVehicleSavingResult(
        Result<Vehicle> vehicleInstantiationResult,
        CancellationToken cancellationToken)
    {
        // (vehicleInstantiationResult.Value!.Images as List<VehicleImage>)!.AddRange(imagesUploadResult.Value!);
        await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleInstantiationResult.Value!);
        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        // if (!saveResult) await imageService.TryRollbackImageUploadAsync();

        return saveResult;
    }
}
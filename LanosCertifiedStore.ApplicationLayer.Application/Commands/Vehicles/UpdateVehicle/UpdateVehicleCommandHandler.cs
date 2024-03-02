using Application.Commands.Vehicles.Common;
using Application.Contracts.ServicesRelated.ImageService;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IImageService imageService) : ActionVehicleCommandHandlerBase, IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedEntity = await unitOfWork.RetrieveRepository<Vehicle>().GetEntityByIdAsync(request.Id);

        if (updatedEntity is null)
            return Result<Unit>.Failure(Error.NotFound);

        var requestVehicleResult =
            await CreateVehicleBaseInstance(unitOfWork, request);

        if (!requestVehicleResult.IsSuccess)
            return Result<Unit>.Failure(requestVehicleResult.Error!);

        await TrySetupNewVehicleData(request, requestVehicleResult.Value!, updatedEntity);

        var result = await GetVehicleUpdateResult(updatedEntity!, cancellationToken);

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("UpdateError", "Failed to update a vehicle!"));
    }

    private async Task TrySetupNewVehicleData(
        UpdateVehicleCommand request,
        Vehicle requestVehicleResult,
        Vehicle updatedEntity)
    {
        await TryUpdatePrice(request, updatedEntity);
        mapper.Map(requestVehicleResult, updatedEntity!);
    }

    private async Task TryUpdatePrice(UpdateVehicleCommand request, Vehicle vehicle)
    {
        if (IsAlteredPriceValue(request, vehicle!))
            await InitializeNewPrice(request, vehicle!);
    }

    private async Task<bool> GetVehicleUpdateResult(
        Vehicle vehicleToUpdate, CancellationToken cancellationToken)
    {
        unitOfWork.RetrieveRepository<Vehicle>().UpdateExistingEntityAsync(vehicleToUpdate);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!result) await imageService.TryRollbackImageUploadAsync();

        return result;
    }

    private async Task InitializeNewPrice(UpdateVehicleCommand request, Vehicle updatedVehicle)
    {
        var newPrice = new VehiclePrice(updatedVehicle, request.Price);

        await unitOfWork.RetrieveRepository<VehiclePrice>().AddNewEntityAsync(newPrice);
    }

    private bool IsAlteredPriceValue(UpdateVehicleCommand request, Vehicle updatedVehicle) =>
        !updatedVehicle.Prices.MaxBy(p => p.IssueDate)!.Value.Equals(request.Price);
}
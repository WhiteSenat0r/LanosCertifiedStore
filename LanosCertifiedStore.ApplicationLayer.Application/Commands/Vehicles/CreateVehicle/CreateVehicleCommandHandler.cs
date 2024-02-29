using Application.Commands.Vehicles.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : ActionVehicleCommandHandlerBase, IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleInstantiationResult =
            await CreateVehicleBaseInstance(unitOfWork, request);

        if (!vehicleInstantiationResult.IsSuccess)
            return Result<Unit>.Failure(vehicleInstantiationResult.Error!);

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
        await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleInstantiationResult.Value!);
        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return saveResult;
    }
}
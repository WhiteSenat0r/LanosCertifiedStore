using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleCreateResult = await CreateVehicle(request);

        if (!vehicleCreateResult.IsSuccess)
            return Result<Unit>.Failure(vehicleCreateResult.Error);

        await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleCreateResult.Value);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create a vehicle!");
    }

    private async Task<Result<Vehicle>> CreateVehicle(CreateVehicleCommand request)
    {
        var vehicleModel =
            await unitOfWork.RetrieveRepository<VehicleModel>().GetEntityByIdAsync(request.Vehicle.ModelId);

        if (vehicleModel is null)
            return Result<Vehicle>.Failure("Such model doesn't exists!");

        var vehicleBrand =
            await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.Vehicle.BrandId);

        if (vehicleBrand is null)
            return Result<Vehicle>.Failure("Such brand doesn't exists!");

        var vehicleColor =
            await unitOfWork.RetrieveRepository<VehicleColor>().GetEntityByIdAsync(request.Vehicle.ColorId);

        if (vehicleColor is null)
            return Result<Vehicle>.Failure("Such color doesn't exists!");

        var vehicleType = await unitOfWork.RetrieveRepository<VehicleType>().GetEntityByIdAsync(request.Vehicle.TypeId);

        if (vehicleType is null)
            return Result<Vehicle>.Failure("Such type doesn't exists!");

        var vehicleDisplacement =
            await unitOfWork.RetrieveRepository<VehicleDisplacement>()
                .GetEntityByIdAsync(request.Vehicle.DisplacementId);

        if (vehicleDisplacement is null)
            return Result<Vehicle>.Failure("Such displacement doesn't exists!");

        var vehicle = new Vehicle(
            brand: vehicleBrand,
            model: vehicleModel,
            color: vehicleColor,
            type: vehicleType,
            displacement: vehicleDisplacement,
            price: request.Vehicle.Price,
            description: request.Vehicle.Description);

        return Result<Vehicle>.Success(vehicle);
    }
}
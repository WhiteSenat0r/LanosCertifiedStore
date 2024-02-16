using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleCreateResult = await CreateVehicle(request);

        if (!vehicleCreateResult.IsSuccess)
            return Result<Unit>.Failure(vehicleCreateResult.Error!);

        await unitOfWork.RetrieveRepository<Vehicle>().AddNewEntityAsync(vehicleCreateResult.Value!);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result
            ? Result<Unit>.Success(Unit.Value)
            : Result<Unit>.Failure(new Error("CreateError", "Failed to create a vehicle!"));
    }

    private async Task<Result<Vehicle>> CreateVehicle(CreateVehicleCommand request)
    {
        var vehicleModel =
            await unitOfWork.RetrieveRepository<VehicleModel>().GetEntityByIdAsync(request.ActionVehicleDto.ModelId);

        if (vehicleModel is null)
            return Result<Vehicle>.Failure(new Error("NotFound", "Such model doesn't exists!"));

        var vehicleBrand =
            await unitOfWork.RetrieveRepository<VehicleBrand>().GetEntityByIdAsync(request.ActionVehicleDto.BrandId);

        if (vehicleBrand is null)
            return Result<Vehicle>.Failure(new Error("NotFound", "Such brand doesn't exists!"));

        var vehicleColor =
            await unitOfWork.RetrieveRepository<VehicleColor>().GetEntityByIdAsync(request.ActionVehicleDto.ColorId);

        if (vehicleColor is null)
            return Result<Vehicle>.Failure(new Error("NotFound", "Such color doesn't exists!"));

        var vehicleType = await unitOfWork.RetrieveRepository<VehicleType>().GetEntityByIdAsync(request.ActionVehicleDto.TypeId);

        if (vehicleType is null)
            return Result<Vehicle>.Failure(new Error("NotFound", "Such type doesn't exists!"));

        var vehicleDisplacement =
            await unitOfWork.RetrieveRepository<VehicleDisplacement>()
                .GetEntityByIdAsync(request.ActionVehicleDto.DisplacementId);

        if (vehicleDisplacement is null)
            return Result<Vehicle>.Failure(new Error("NotFound", "Such displacement doesn't exists!"));

        var vehicle = new Vehicle(
            brand: vehicleBrand,
            model: vehicleModel,
            color: vehicleColor,
            type: vehicleType,
            displacement: vehicleDisplacement,
            price: request.ActionVehicleDto.Price,
            description: request.ActionVehicleDto.Description);

        return Result<Vehicle>.Success(vehicle);
    }
}
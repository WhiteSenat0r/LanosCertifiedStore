using Application.Core;
using Application.Dtos.VehicleDtos;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(
    IRepository<Vehicle> vehicleRepository,
    IRepository<VehicleModel> modelRepository,
    IRepository<VehicleBrand> brandRepository,
    IRepository<VehicleColor> colorRepository,
    IRepository<VehicleType> typeRepository,
    IRepository<VehicleDisplacement> displacementRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleCreateResult = await CreateVehicle(request.Vehicle);

        if (!vehicleCreateResult.IsSuccess)
            return Result<Unit>.Failure(vehicleCreateResult.Error);
        
        await vehicleRepository.AddNewEntityAsync(vehicleCreateResult.Value);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create a vehicle!");
    }

    private async Task<Result<Vehicle>> CreateVehicle(ActionVehicleDto vehicleRequest)
    {
        var vehicleModel = await modelRepository.GetEntityByIdAsync(vehicleRequest.ModelId);

        if (vehicleModel is null)
            return Result<Vehicle>.Failure("Such model doesn't exists!");

        var vehicleBrand = await brandRepository.GetEntityByIdAsync(vehicleRequest.BrandId);

        if (vehicleBrand is null)
            return Result<Vehicle>.Failure("Such brand doesn't exists!");

        var vehicleColor = await colorRepository.GetEntityByIdAsync(vehicleRequest.ColorId);

        if (vehicleColor is null)
            return Result<Vehicle>.Failure("Such color doesn't exists!");

        var vehicleType = await typeRepository.GetEntityByIdAsync(vehicleRequest.TypeId);

        if (vehicleType is null)
            return Result<Vehicle>.Failure("Such type doesn't exists!");

        var vehicleDisplacement = await displacementRepository.GetEntityByIdAsync(vehicleRequest.DisplacementId);

        if (vehicleDisplacement is null)
            return Result<Vehicle>.Failure("Such displacement doesn't exists!");

        var vehicle = new Vehicle(
            brand: vehicleBrand,
            model: vehicleModel,
            color: vehicleColor,
            type: vehicleType,
            displacement: vehicleDisplacement,
            price: vehicleRequest.Price,
            description: vehicleRequest.Description);
        
        return Result<Vehicle>.Success(vehicle);
    }
}
using Application.Core;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(
    IRepository<Vehicle> vehicleRepository,
    IRepository<VehicleModel> modelRepository,
    IRepository<VehicleBrand> brandRepository,
    IRepository<VehicleColor> colorRepository,
    IRepository<VehicleType> typeRepository,
    IRepository<VehicleDisplacement> displacementRepository,
    IRepository<VehiclePrice> vehiclePriceRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleToUpdate = await vehicleRepository.GetEntityByIdAsync(request.ActionVehicleDto.Id);

        if (vehicleToUpdate is null)
            return Result<Unit>.Failure("Such vehicle doesn't exists!");

        var createRequestVehicleResult = await CreateVehicle(request);

        if (!createRequestVehicleResult.IsSuccess)
            return Result<Unit>.Failure(createRequestVehicleResult.Error);


        ApplyChangesDataOnUpdatedVehicle(createRequestVehicleResult.Value, vehicleToUpdate);

        if (IsAlteredPriceValue(request, vehicleToUpdate))
            await InitializeNewPriceAsync(request, vehicleToUpdate);

        vehicleRepository.UpdateExistingEntity(vehicleToUpdate);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update a vehicle!");
    }

    private async Task InitializeNewPriceAsync(UpdateVehicleCommand request, Vehicle updatedVehicle)
    {
        var newPrice = new VehiclePrice(updatedVehicle, request.ActionVehicleDto.Price);

        await vehiclePriceRepository.AddNewEntityAsync(newPrice);

        updatedVehicle.Prices.Add(newPrice);
    }

    private void ApplyChangesDataOnUpdatedVehicle(Vehicle vehicle, Vehicle updatedVehicle)
    {
        mapper.Map(vehicle, updatedVehicle);
    }

    private bool IsAlteredPriceValue(UpdateVehicleCommand request, Vehicle updatedVehicle) =>
        !updatedVehicle.Prices.MaxBy(p => p.IssueDate)!.Value.Equals(request.ActionVehicleDto.Price);

    private async Task<Result<Vehicle>> CreateVehicle(UpdateVehicleCommand request)
    {
        var vehicleModel = await modelRepository.GetEntityByIdAsync(request.ActionVehicleDto.ModelId);

        if (vehicleModel is null)
            return Result<Vehicle>.Failure("Such model doesn't exists!");

        var vehicleBrand = await brandRepository.GetEntityByIdAsync(request.ActionVehicleDto.BrandId);

        if (vehicleBrand is null)
            return Result<Vehicle>.Failure("Such brand doesn't exists!");

        var vehicleColor = await colorRepository.GetEntityByIdAsync(request.ActionVehicleDto.ColorId);

        if (vehicleColor is null)
            return Result<Vehicle>.Failure("Such color doesn't exists!");

        var vehicleType = await typeRepository.GetEntityByIdAsync(request.ActionVehicleDto.TypeId);

        if (vehicleType is null)
            return Result<Vehicle>.Failure("Such type doesn't exists!");

        var vehicleDisplacement =
            await displacementRepository.GetEntityByIdAsync(request.ActionVehicleDto.DisplacementId);

        if (vehicleDisplacement is null)
            return Result<Vehicle>.Failure("Such displacement doesn't exists!");

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

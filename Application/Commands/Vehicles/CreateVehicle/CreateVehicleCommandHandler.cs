using Application.Core;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.CreateVehicle;

internal sealed class CreateVehicleCommandHandler(IRepository<Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(
            brandId: request.Vehicle.BrandId,
            modelId: request.Vehicle.ModelId,
            typeId: request.Vehicle.TypeId,
            colorId: request.Vehicle.ColorId,
            displacementId: request.Vehicle.DisplacementId,
            description: request.Vehicle.Description);

        await vehicleRepository.AddNewEntityAsync(vehicle);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to create a vehicle!");
    }
}
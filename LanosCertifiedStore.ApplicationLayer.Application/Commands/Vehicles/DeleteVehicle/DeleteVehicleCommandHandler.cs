using Application.Core;
using Application.QuerySpecifications.VehiclesRelated;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.DeleteVehicle;

internal sealed class DeleteVehicleCommandHandler(
    IRepository<Vehicle> vehicleRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var deleteVehicle = await vehicleRepository.GetSingleEntityBySpecificationAsync(
                new VehicleByIdQuerySpecification(request.Id));
        
        if (deleteVehicle is null) 
            return Result<Unit>.Failure("Such vehicle doesn't exists!");
        
        vehicleRepository.RemoveExistingEntity(deleteVehicle);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete a vehicle!");
    }
}
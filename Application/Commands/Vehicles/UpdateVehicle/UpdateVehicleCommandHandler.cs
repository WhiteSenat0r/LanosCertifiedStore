using Application.Core;
using Application.QuerySpecifications.VehiclesRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(
    IRepository<Vehicle> vehicleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedVehicle = await vehicleRepository.GetSingleEntityBySpecificationAsync(
                new VehicleByIdQuerySpecification(request.ActionVehicleDto.Id));

        ApplyChangedDataOnUpdatedVehicle(request, updatedVehicle);
        
        if (IsAlteredPriceValue(request, updatedVehicle))
            updatedVehicle.Price.Add(new VehiclePrice(updatedVehicle.Id, request.ActionVehicleDto.Price));
        
        vehicleRepository.UpdateExistingEntity(updatedVehicle);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update a vehicle!");
    }

    private void ApplyChangedDataOnUpdatedVehicle(UpdateVehicleCommand request, Vehicle updatedVehicle) => 
        mapper.Map(request.ActionVehicleDto, updatedVehicle);

    private bool IsAlteredPriceValue(UpdateVehicleCommand request, Vehicle updatedVehicle) => 
        !updatedVehicle.Price.MaxBy(p => p.IssueDate).Value.Equals(request.ActionVehicleDto.Price);
}
using Application.Core;
using Application.QuerySpecifications.VehiclesRelated;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using MediatR;

namespace Application.Commands.Vehicles.UpdateVehicle;

internal sealed class UpdateVehicleCommandHandler(
    IRepository<Vehicle> vehicleRepository,
    IRepository<VehiclePrice> vehiclePriceRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateVehicleCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var updatedVehicle = await vehicleRepository.GetSingleEntityBySpecificationAsync(
                new VehicleByIdQuerySpecification(request.ActionVehicleDto.Id));
        
        if (updatedVehicle is null)
            return Result<Unit>.Failure("Such vehicle doesn't exists!");

        ApplyChangesDataOnUpdatedVehicle(request, updatedVehicle);
        
        if (IsAlteredPriceValue(request, updatedVehicle)) 
            await InitializeNewPriceAsync(request, updatedVehicle);
        
        vehicleRepository.UpdateExistingEntity(updatedVehicle);

        var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update a vehicle!");
    }

    private async Task InitializeNewPriceAsync(UpdateVehicleCommand request, Vehicle updatedVehicle)
    {
        var newPrice = new VehiclePrice(updatedVehicle.Id, request.ActionVehicleDto.Price);
            
        await vehiclePriceRepository.AddNewEntityAsync(newPrice);
            
        updatedVehicle.Prices.Add(newPrice);
    }

    private void ApplyChangesDataOnUpdatedVehicle(UpdateVehicleCommand request, Vehicle updatedVehicle) => 
        mapper.Map(request.ActionVehicleDto, updatedVehicle);

    private bool IsAlteredPriceValue(UpdateVehicleCommand request, Vehicle updatedVehicle) => 
        !updatedVehicle.Prices.MaxBy(p => p.IssueDate).Value.Equals(request.ActionVehicleDto.Price);
}
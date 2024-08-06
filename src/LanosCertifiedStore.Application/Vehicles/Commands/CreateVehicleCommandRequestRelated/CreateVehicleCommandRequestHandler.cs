using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.VehicleRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.CreateVehicleCommandRequestRelated;

internal sealed class CreateVehicleCommandHandler(
    IVehicleService vehicleService,
    IUserContext userContext) : IRequestHandler<CreateVehicleCommandRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
    {
        var creatorId = userContext.UserId;

        var vehicle = new Vehicle(
            request.BrandId,
            request.ModelId,
            request.VehicleTypeId,
            request.DrivetrainTypeId,
            request.EngineTypeId,
            request.BodyTypeId,
            request.TransmissionTypeId,
            request.ColorId,
            request.LocationTownId,
            creatorId,
            request.Price,
            request.Displacement,
            request.Description,
            request.ProductionYear,
            request.Mileage);

        await vehicleService.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }
}
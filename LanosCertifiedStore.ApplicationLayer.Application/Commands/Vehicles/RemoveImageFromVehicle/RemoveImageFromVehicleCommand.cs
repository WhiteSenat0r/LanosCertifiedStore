using Domain.Shared;
using MediatR;

namespace Application.Commands.Vehicles.RemoveImageFromVehicle;

public record RemoveImageFromVehicleCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
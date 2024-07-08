using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Vehicles.RemoveImageFromVehicle;

public record RemoveImageFromVehicleCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
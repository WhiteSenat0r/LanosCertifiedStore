using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Images.Commands.RemoveImageFromVehicle;

public record RemoveImageFromVehicleCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
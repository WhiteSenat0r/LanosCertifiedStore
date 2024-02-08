using Application.Core;
using MediatR;

namespace Application.Commands.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(Guid Id) : IRequest<Result<Unit>>;
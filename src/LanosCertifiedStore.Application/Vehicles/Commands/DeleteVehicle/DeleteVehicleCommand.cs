using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Vehicles.Commands.DeleteVehicle;

public record DeleteVehicleCommand(Guid Id) : IRequest<Result<Unit>>;
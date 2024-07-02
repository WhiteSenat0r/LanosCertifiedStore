using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(Guid Id) : IRequest<Result<Unit>>;
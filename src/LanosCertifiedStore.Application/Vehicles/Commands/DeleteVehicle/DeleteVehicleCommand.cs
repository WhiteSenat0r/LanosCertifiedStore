using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Vehicles.Commands.DeleteVehicle;

public record DeleteVehicleCommand(Guid Id) : IRequest<Result<Unit>>;
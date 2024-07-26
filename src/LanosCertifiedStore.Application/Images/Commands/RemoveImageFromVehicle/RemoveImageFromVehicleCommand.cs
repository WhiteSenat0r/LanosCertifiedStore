using LanosCertifiedStore.Application.Shared.ResultRelated;
using MediatR;

namespace LanosCertifiedStore.Application.Images.Commands.RemoveImageFromVehicle;

public record RemoveImageFromVehicleCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
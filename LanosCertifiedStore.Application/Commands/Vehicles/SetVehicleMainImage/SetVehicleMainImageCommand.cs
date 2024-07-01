using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.Vehicles.SetVehicleMainImage;

public sealed record SetVehicleMainImageCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Images.Commands.SetVehicleMainImage;

public sealed record SetVehicleMainImageCommand(Guid VehicleId, Guid ImageId) : IRequest<Result<Unit>>;
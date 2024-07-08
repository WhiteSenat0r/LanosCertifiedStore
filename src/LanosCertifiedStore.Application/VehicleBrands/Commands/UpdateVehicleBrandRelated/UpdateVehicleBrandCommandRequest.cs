using Application.Shared.RequestRelated;
using MediatR;

namespace Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;

public sealed record UpdateVehicleBrandCommandRequest(Guid Id, string UpdatedName) : ICommandRequest<Unit>;
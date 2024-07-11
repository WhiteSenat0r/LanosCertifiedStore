using Application.Shared.RequestRelated;

namespace Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

public sealed record CreateVehicleBrandCommandRequest(
    string Name) : ICommandRequest<Guid>;
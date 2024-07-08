using Application.Contracts.RequestRelated;

namespace Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;

public sealed record CreateVehicleBrandCommandRequest(
    string Name) : ICommandRequest<Guid>;
using Application.Contracts.RequestRelated;
using Domain.Entities.VehicleRelated;

namespace Application.CommandRequests.VehicleBrandsRelated.CreateVehicleBrandRelated;

public sealed record CreateVehicleBrandCommandRequest(
    string Name) : ICommandRequest<VehicleBrand, Guid>;
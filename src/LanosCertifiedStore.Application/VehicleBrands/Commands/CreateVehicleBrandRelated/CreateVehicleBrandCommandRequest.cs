using LanosCertifiedStore.Application.Shared.RequestRelated;

namespace LanosCertifiedStore.Application.VehicleBrands.Commands.CreateVehicleBrandRelated;

public sealed record CreateVehicleBrandCommandRequest(
    string Name) : ICommandRequest<Guid>;
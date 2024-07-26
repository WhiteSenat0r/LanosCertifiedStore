using LanosCertifiedStore.Application.Shared.RequestRelated;
using MediatR;

namespace LanosCertifiedStore.Application.VehicleBrands.Commands.UpdateVehicleBrandRelated;

public sealed record UpdateVehicleBrandCommandRequest(Guid Id, string UpdatedName) : ICommandRequest<Unit>;
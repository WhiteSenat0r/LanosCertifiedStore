using Application.Contracts.RequestRelated;
using MediatR;

namespace Application.CommandRequests.VehicleBrandsRelated.UpdateVehicleBrandRelated;

public sealed record UpdateVehicleBrandCommandRequest(Guid Id, string UpdatedName) : ICommandRequest<Unit>;
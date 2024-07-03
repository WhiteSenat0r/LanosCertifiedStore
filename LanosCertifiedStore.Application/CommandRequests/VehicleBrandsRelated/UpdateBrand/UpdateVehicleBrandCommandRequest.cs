using Application.Contracts.RequestRelated;
using MediatR;

namespace Application.CommandRequests.VehicleBrandsRelated.UpdateBrand;

public sealed record UpdateVehicleBrandCommandRequest(Guid Id, string UpdatedName) : ICommandRequest<Unit>;
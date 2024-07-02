using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.VehicleBrandsRelated.UpdateBrand;

public sealed record UpdateBrandCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;
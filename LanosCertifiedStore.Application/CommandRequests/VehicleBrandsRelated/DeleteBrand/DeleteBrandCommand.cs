using Application.Shared.ResultRelated;
using MediatR;

namespace Application.CommandRequests.VehicleBrandsRelated.DeleteBrand;

public sealed record DeleteBrandCommand(Guid Id) : IRequest<Result<Unit>>;
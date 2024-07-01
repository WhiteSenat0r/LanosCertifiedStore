using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Commands.VehicleBrandsRelated.DeleteBrand;

public sealed record DeleteBrandCommand(Guid Id) : IRequest<Result<Unit>>;
using Application.Shared;
using MediatR;

namespace Application.Commands.Brands.UpdateBrand;

public sealed record UpdateBrandCommand(Guid Id, string UpdatedName) : IRequest<Result<Unit>>;
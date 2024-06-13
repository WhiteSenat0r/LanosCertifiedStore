using Application.Shared;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand;

public sealed record DeleteBrandCommand(Guid Id) : IRequest<Result<Unit>>;
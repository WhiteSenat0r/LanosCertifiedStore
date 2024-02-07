using Application.Core;
using MediatR;

namespace Application.Commands.Brands.DeleteBrand;

public sealed record DeleteBrandCommand(string Name) : IRequest<Result<Unit>>;
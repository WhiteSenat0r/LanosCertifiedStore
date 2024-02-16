using Domain.Shared;
using MediatR;

namespace Application.Commands.Brands.CreateBrand;

public sealed record CreateBrandCommand(string Name) : IRequest<Result<Unit>>;